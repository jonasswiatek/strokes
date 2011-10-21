// Ignore warnings in the test file.
#pragma warning disable
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using Strokes.BasicAchievements.Achievements;
using Strokes.Core;
using System.Linq;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;
using Strokes.Data;
using Strokes.GUI;
using Strokes.Service;
using Strokes.Service.Data;
using Strokes.VSX;
using StructureMap;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) 
        {
            ObjectFactory.Configure(a =>
                                        {
                                            a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>().Ctor<string>("storageFile").Is("AchievementStorage_ConsoleTest.xml");
                                            a.For<IAchievementService>().Singleton().Use<SerialStrokesAchievementService>();
                                        });

            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            achievementService.LoadAchievementsFrom(typeof(ArrayLengthPropertyAchievement).Assembly);

            var cultureToTest = "ru-RU"; // Set to "ru-RU" to enable russian. Set to "nl" for dutch

            // Comment the following line to use operating system default culture.
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureToTest);

            achievementService.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
            GuiInitializer.Initialize();

            achievementService.ResetAchievementProgress();

            achievementService.StaticAnalysisCompleted += DetectionDispatcher_DetectionCompleted;
            var file = System.IO.Path.GetFullPath("TestFile.cs");
            achievementService.PerformStaticAnalysis(new StaticAnalysisManifest()
            {
                ActiveFile = file,
                ChangedFiles = new string[] { file },
                CodeFiles = new string[] { file }
            }, true);

            System.Console.Read();
        }

        private static void DetectionDispatcher_DetectionCompleted(object sender, StaticAnalysisEventArgs e)
        {
            System.Console.WriteLine(string.Format("{0} achievements tested in {1} milliseconds",
                e.AchievementsTested, e.ElapsedMilliseconds));
        }

        private static void AchievementContext_AchievementsUnlocked(object sender, AchievementEventArgs args)
        {
            System.Console.WriteLine("Unlocked: " + string.Join(", ", args.UnlockedAchievements.Select(a => a.Name)));
        }
    }
}

#pragma warning restore