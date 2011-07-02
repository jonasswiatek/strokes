using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;
using Strokes.CSharpCodeGraph.CodeElements;
using Strokes.CSharpCodeGraph.CodeElements.TypeDeclarations;

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
            doc.Add(new ClassDeclaration(modifiers));
        }

        public static void StructDeclaration(this CodeDocument doc, Token token, IEnumerable<Modifier> modifiers)
        {
            Trace.WriteLine("Struct: " + token.val);
            doc.Add(new StructDeclaration(modifiers));
        }

        public static void InterfaceDeclaration(this CodeDocument doc, Token token, IEnumerable<Modifier> modifiers)
        {
            Trace.WriteLine("Interface: " + token.val);
            doc.Add(new InterfaceDeclaration(modifiers));
        }

        public static void EnumDeclaration(this CodeDocument doc, Token token, IEnumerable<Modifier> modifiers)
        {
            Trace.WriteLine("Enum: " + token.val);
            doc.Add(new EnumDeclaration(modifiers));
        }

        public static void EndType(this CodeDocument doc, Token t)
        {
            Trace.WriteLine("End type");
            doc.EndTypeDeclaration();
        }

        public static void BaseClass(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("BaseClass: " + token.val);
        }

        public static void ImplementInterface(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("Implement interface: " + token.val);
            var interfaceImplementation = new NamedType();
            doc.CurrentNamedType = interfaceImplementation;
            doc.CurrentTypeDeclaration.Interfaces.Add(interfaceImplementation);
        }

        public static void TypeName(this CodeDocument doc, Token token)
        {
            Trace.WriteLine("NamedTypeName: " + token.val);
            doc.ProcessTypeName(token);
        }
    }
}
