using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Resolver;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    namespace Strokes.BasicAchievements.NRefactory
    {
        public class NRefactorySession : IDisposable
        {
            private readonly object _parserAccessPadLock = new object();
            private readonly object _codebaseTypeDefinitionPadLock = new object();

            private readonly IDictionary<string, CompilationUnit> _parsers = new Dictionary<string, CompilationUnit>();
            private List<TypeDeclarationInfo> _codebaseTypeDefinitions;

            /// <summary>
            /// Creates a parser for the specified file. This parser is cached for this (one) detection session.
            /// This method is thread safe.
            /// </summary>
            /// <param name="filename"></param>
            /// <returns></returns>
            public CompilationUnit GetCompilationUnit(string filename)
            {
                lock(_parserAccessPadLock) //Synchronize
                {
                    if (!_parsers.ContainsKey(filename))
                    {
                        var parser = new CSharpParser();
                        var compilationUnit = parser.Parse(File.OpenRead(filename));
                        
                        _parsers.Add(filename, compilationUnit);
                    }

                    return _parsers[filename];
                }
            }

            /// <summary>
            /// Gets all type declarations made in the current codebase that is being compiled. This is a tool method to be used in more complex achievements.
            /// This method is caching and can be called without discretion, and is thread safe.
            /// </summary>
            /// <param name="buildInformation">BuildInformation object used to locate the codebase</param>
            /// <returns>Cached collection of TypeDeclarationInfo</returns>
            public IEnumerable<TypeDeclarationInfo> GetCodebaseTypeDeclarations(BuildInformation buildInformation)
            {
                lock(_codebaseTypeDefinitionPadLock)
                {
                    if(_codebaseTypeDefinitions == null)
                    {
                        _codebaseTypeDefinitions = new List<TypeDeclarationInfo>();
                        foreach(var filename in buildInformation.CodeFiles)
                        {
                            var compilationUnit = GetCompilationUnit(filename);
                            var typeDeclarationInfoVisitor = new TypeDeclarationVisitor();
                            compilationUnit.AcceptVisitor(typeDeclarationInfoVisitor, null);

                            _codebaseTypeDefinitions.AddRange(typeDeclarationInfoVisitor.TypeDeclarations);
                        }
                    }

                    return _codebaseTypeDefinitions;
                }
            }

            public void Dispose()
            {
            }
        }
    }
}