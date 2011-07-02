using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.CSharpCodeGraph
{
    public class CodeDocument
    {
        public static CodeDocument From(string fileName)
        {
            var scanner = new Scanner(fileName);
            var parser = new Parser(scanner);
            parser.Parse();

            return parser.doc;
        }

        public IList<UsingDirective> Usings = new List<UsingDirective>();
        public IList<Namespace> Namespaces = new List<Namespace>();
        public IList<TypeDeclaration> TypeDeclarations = new List<TypeDeclaration>();

        internal Namespace CurrentNamespace;
        internal TypeDeclaration CurrentType;

        internal void Add(CodeElement element)
        {
            if(element is ITypeNamed)
            {
                _currentTypeNamed = (ITypeNamed)element;
            }

            if(element is UsingDirective)
            {
                Usings.Add((UsingDirective) element);
            }
            else if(element is Namespace)
            {
                CurrentNamespace = (Namespace) element;
                Namespaces.Add((Namespace) element);
            }
            else if(element is TypeDeclaration)
            {
                if(CurrentNamespace != null)
                {
                    CurrentNamespace.TypeDeclarations.Add((TypeDeclaration)element);
                }
                else
                {
                    TypeDeclarations.Add((TypeDeclaration)element);
                }
            }
        }

        private ITypeNamed _currentTypeNamed;
        internal void ProcessTypeName(Token token)
        {
            _currentTypeNamed.AddTypeNameFromToken(token);
        }

        internal void EndNamespace()
        {
            CurrentNamespace = null;
        }

        internal void EndType()
        {
            CurrentNamespace = null;
        }
    }
}
