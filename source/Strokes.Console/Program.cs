using System;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using Strokes.AchievementDispatcher;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var scanner = new Scanner(System.IO.Path.GetFullPath("TestFile.cs"));
            var parser = new Parser(scanner);

            parser.Parse();

            System.Console.WriteLine("FIELDS");
            foreach(var field in parser.Graph.DeclaredFields)
            {
                System.Console.WriteLine(string.Format("On line {3} -- Field Type: {0}, Field declaration count: {1}, initialized: {2}, modifiers: {4}", field.FieldType, field.DeclarationCount, field.IsInitialized, field.Token.line, string.Join(", ", field.Modifiers)));
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("CONSTANTS");
            foreach (var constant in parser.Graph.DeclaredConstants)
            {
                System.Console.WriteLine(string.Format("On line {2} -- Constant Type: {0}, Field declaration count: {1}, modifiers: {3}", constant.FieldType, constant.DeclarationCount, constant.Token.line, string.Join(", ", constant.Modifiers)));
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("PROPERTIES");
            foreach (var property in parser.Graph.DeclaredProperties)
            {
                System.Console.WriteLine(string.Format("On line {2} -- Property type: {0}, private setter: {1}, modifiers: {3}", property.PropertyType, property.HasPrivateSetter, property.Token.line, string.Join(", ", property.Modifiers)));
            }

            System.Console.Read();

            /* Don't delete this: it's for testing the addon, but disabled because I needed the space for something else.
            var buildInfo = new BuildInformation()
            {
                ActiveFile = System.IO.Path.GetFullPath("TestFile.cs")
            };

            var dispatched = DetectionDispatcher.Dispatch(buildInfo);

            if (!dispatched)
            {
                new Application().Run(new AchievementIndex());
            }*/
        }
    }
}