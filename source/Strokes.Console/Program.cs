using System;
using System.IO;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (IParser parser = ParserFactory.CreateParser(System.IO.Path.GetFullPath("TestFile.cs")))
            {
                parser.Parse();
                // this allows retrieving comments, preprocessor directives, etc. (stuff that isn't part of the syntax)
                var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();
                // this retrieves the root node of the result AST
                var result = parser.CompilationUnit;
                
                if (parser.Errors.Count > 0)
                {
                    MessageBox.Show(parser.Errors.ErrorOutput, "Parse errors");
                }

                result.AcceptVisitor(new AchievementVisitor(), null);
                var bla = "";
            }

            System.Console.Read();
        }
    }
}