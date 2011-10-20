using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactorySession : IDisposable
    {
        private readonly object parserAccessPadLock = new object();
        private readonly object codebaseTypeDefinitionPadLock = new object();
        private readonly IDictionary<string, CompilationUnit> parsers = new Dictionary<string, CompilationUnit>();
        private List<DeclarationInfo> codebaseDeclarations;

        /// <summary>
        /// Creates a parser for the specified file. This parser is cached for this (one) detection session.
        /// This method is thread safe.
        /// </summary>
        /// <param name="filename">The path and name of the file to create a parser for.</param>
        /// <returns>A <c>IParser</c> for the given file.</returns>
        public CompilationUnit GetCompilationUnit(string filename)
        {
            lock (parserAccessPadLock) // Synchronize
            {
                if (!parsers.ContainsKey(filename))
                {
                    var parser = new CSharpParser();
                    var compilationUnit = parser.Parse(File.OpenRead(filename));

                    parsers.Add(filename, compilationUnit);
                }

                return parsers[filename];
            }
        }

        /// <summary>
        /// Gets all type declarations made in the current codebase that is being compiled. 
        /// This is a tool method to be used in more complex achievements.
        /// This method is caching and can be called without discretion, and is thread safe.
        /// </summary>
        /// <param name="staticAnalysisManifest">StaticAnalysisManifest object used to locate the codebase</param>
        /// <returns>Cached collection of DeclarationInfo</returns>
        public IEnumerable<DeclarationInfo> GetCodebaseDeclarations(StaticAnalysisManifest staticAnalysisManifest)
        {
            lock (codebaseTypeDefinitionPadLock)
            {
                if (codebaseDeclarations == null)
                {
                    codebaseDeclarations = new List<DeclarationInfo>();

                    foreach (var filename in staticAnalysisManifest.CodeFiles)
                    {
                        var compilationUnit = GetCompilationUnit(filename);
                        var typeDeclarationInfoVisitor = new CodebaseAnalysisVisitor();
                        compilationUnit.AcceptVisitor(typeDeclarationInfoVisitor, null);

                        codebaseDeclarations.AddRange(typeDeclarationInfoVisitor.TypeDeclarations);
                    }
                }

                return codebaseDeclarations;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
