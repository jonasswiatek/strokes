using System;
using System.IO;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.Achievements;
using Strokes.Core;
using System.Linq;
using Strokes.Data;
using Strokes.GUI;
using Strokes.VSX;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var fullChain = true;

            if(!fullChain)
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
            else
            {
                AchievementContext.AchievementsUnlocked += new AchievementContext.AchievementsUnlockedHandler(AchievementContext_AchievementsUnlocked);
                GuiInitializer.Initialize();
                var achievementDescriptorRepository = new AchievementDescriptorRepository(); //TODO: Resolve with IoC
                achievementDescriptorRepository.LoadFromAssembly(typeof(AnonymousObjectAchievement).Assembly);

                var detectionDispatcher = new DetectionDispatcher();
                detectionDispatcher.Dispatch(new BuildInformation()
                {
                    ActiveFile = System.IO.Path.GetFullPath("TestFile.cs")
                });

                System.Console.Read();
            }
        }

        static void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            System.Console.WriteLine("Unlocked: " + string.Join(", ", args.Achievements.Select(a => a.Name)));
        }
    }
}