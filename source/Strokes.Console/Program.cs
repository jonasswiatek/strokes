using System;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using Strokes.Core;
using Strokes.CSharpCodeGraph;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var codeGraph = CodeDocument.From(System.IO.Path.GetFullPath("TestFile.cs"));
            
            System.Console.WriteLine("Using directives");
            foreach(var usingDirective in codeGraph.Usings)
            {
                System.Console.WriteLine(usingDirective.FullName);
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Namespaces");
            foreach (var nameSpace in codeGraph.Namespaces)
            {
                System.Console.WriteLine(nameSpace.FullName);
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Type declarations");
            foreach (var typeDeclaration in codeGraph.TypeDeclarations)
            {
                System.Console.WriteLine(typeDeclaration.FullName);
            }

            System.Console.Read();
        }
    }
}