using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactorySession : IDisposable
    {
        private readonly object parserAccessPadLock = new object();
        private readonly object codebaseTypeDefinitionPadLock = new object();
        private readonly IDictionary<string, IParser> parsers = new Dictionary<string, IParser>();
        private List<TypeDeclarationInfo> codebaseTypeDefinitions;

        /// <summary>
        /// Creates a parser for the specified file. This parser is cached for this (one) detection session.
        /// This method is thread safe.
        /// </summary>
        /// <param name="filename">The path and name of the file to create a parser for.</param>
        /// <returns>A <c>IParser</c> for the given file.</returns>
        public IParser GetParser(string filename)
        {
            lock (parserAccessPadLock) // Synchronize
            {
                if (!parsers.ContainsKey(filename))
                {
                    var parser = ParserFactory.CreateParser(filename);
                    parser.Parse();

                    parsers.Add(filename, parser);
                }

                return parsers[filename];
            }
        }

        /// <summary>
        /// Gets all type declarations made in the current codebase that is being compiled. 
        /// This is a tool method to be used in more complex achievements.
        /// This method is caching and can be called without discretion, and is thread safe.
        /// </summary>
        /// <param name="buildInformation">BuildInformation object used to locate the codebase</param>
        /// <returns>Cached collection of TypeDeclarationInfo</returns>
        public IEnumerable<TypeDeclarationInfo> GetCodebaseTypeDeclarations(BuildInformation buildInformation)
        {
            lock (codebaseTypeDefinitionPadLock)
            {
                if (codebaseTypeDefinitions == null)
                {
                    codebaseTypeDefinitions = new List<TypeDeclarationInfo>();

                    foreach (var filename in buildInformation.CodeFiles)
                    {
                        var parser = GetParser(filename);
                        var typeDeclarationInfoVisitor = new TypeDeclarationVisitor();
                        parser.CompilationUnit.AcceptVisitor(typeDeclarationInfoVisitor, null);

                        codebaseTypeDefinitions.AddRange(typeDeclarationInfoVisitor.TypeDeclarations);
                    }
                }

                return codebaseTypeDefinitions;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var parser in parsers.Values)
            {
                parser.Dispose();
            }
        }
    }
}