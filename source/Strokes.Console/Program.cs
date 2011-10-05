// Ignore warnings in the test file.
#pragma warning disable
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
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

            var cultureToTest = "ru-RU"; //set to "ru-RU" to enable russian.set to "nl" for dutch
            
            //Comment the following line to use operating system default culture.
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureToTest);

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
                }
                System.Console.Read();
            }
            else
            {
                AchievementContext.AchievementsUnlocked += new AchievementContext.AchievementsUnlockedHandler(AchievementContext_AchievementsUnlocked);
                GuiInitializer.Initialize();

                var achievementDescriptorRepository = new AchievementDescriptorRepository(); //TODO: Resolve with IoC
                achievementDescriptorRepository.LoadFromAssembly(typeof(AnonymousObjectAchievement).Assembly);
                DetectionDispatcher.DetectionCompleted += new EventHandler<DetectionCompletedEventArgs>(DetectionDispatcher_DetectionCompleted);

                DetectionDispatcher.Dispatch(new BuildInformation()
                {
                    ActiveFile = System.IO.Path.GetFullPath("TestFile.cs")
                });

                System.Console.Read();
            }
        }

        static void DetectionDispatcher_DetectionCompleted(object sender, DetectionCompletedEventArgs e)
        {
            System.Console.WriteLine(string.Format("{0} achievements tested in {1} milliseconds", e.AchievementsTested, e.ElapsedMilliseconds));
        }

        static void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            System.Console.WriteLine("Unlocked: " + string.Join(", ", args.Achievements.Select(a => a.Name)));
        }
    }
}

#pragma warning restore