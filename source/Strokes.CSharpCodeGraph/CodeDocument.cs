using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;
using Strokes.CSharpCodeGraph.CodeElements;
using Strokes.CSharpCodeGraph.CodeElements.TypeDeclarations;
using Strokes.CSharpCodeGraph.Interfaces;

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

        #region Exposed elements

        public IList<UsingDirective> Usings = new List<UsingDirective>();
        public IList<Namespace> Namespaces = new List<Namespace>();
        public IList<TypeDeclaration> TypeDeclarations = new List<TypeDeclaration>();

        #endregion

        internal Namespace CurrentNamespace;
        internal TypeDeclaration CurrentTypeDeclaration;
        internal INamedType CurrentNamedType;

        internal void Handle(CodeElement element)
        {
            if(element is INamedType)
            {
                CurrentNamedType = (INamedType)element;
            }
            if(element is TypeDeclaration)
            {
                CurrentTypeDeclaration = (TypeDeclaration) element;
            }
            if(element is Namespace)
            {
                CurrentNamespace = (Namespace) element;
            }
        }

        internal void Add(UsingDirective usingDirective)
        {
            Handle(usingDirective);
            Usings.Add(usingDirective);
        }

        internal void Add(Namespace @namespace)
        {
            Handle(@namespace);
            CurrentNamespace = @namespace;
            Namespaces.Add(@namespace);
        }

        internal void EndNamespace()
        {
            CurrentNamespace = null;
        }

        internal void Add(TypeDeclaration typeDeclaration)
        {
            Handle(typeDeclaration);
            if (CurrentNamespace != null)
            {
                CurrentNamespace.TypeDeclarations.Add(typeDeclaration);
            }
            else
            {
                TypeDeclarations.Add(typeDeclaration);
            }
        }

        internal void EndTypeDeclaration()
        {
            CurrentTypeDeclaration = null;
        }

        
        internal void ProcessTypeName(Token token)
        {
            CurrentNamedType.AddTypeNameFromToken(token);
        }




    }
}
