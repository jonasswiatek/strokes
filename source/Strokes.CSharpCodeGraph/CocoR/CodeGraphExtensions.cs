using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.CSharpCodeGraph.CocoR
{
    public static class CodeGraphExtensions
    {
        public static void UsingDirective(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("Using directive: " + token.val);
            doc.Add(new UsingDirective());
        }

        public static void Namespace(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("Namespace: " + token.val);
            doc.Add(new Namespace());
        }

        public static void EndNamespace(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("End namespace");
            doc.EndNamespace();
        }

        public static void ClassDeclaration(this CodeDocument doc, Token token, IEnumerable<Modifier> modifiers)
        {
            Trace.WriteLine("Class: " + token.val);

            doc.Add(doc.CurrentNamespace == null ? new ClassDeclaration(modifiers) : new ClassDeclaration(modifiers, doc.CurrentNamespace));
        }

        public static void EndType(this CodeDocument doc, Token t)
        {
            Trace.WriteLine("End type");
            doc.EndType();
        }

        public static void TypeName(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("TypeName: " + token.val);
            doc.ProcessTypeName(token);
        }
    }
}
