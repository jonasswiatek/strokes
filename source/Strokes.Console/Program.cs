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
using Strokes.Core.Data;
using Strokes.Data;
using Strokes.GUI;
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
                                            a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>();
                                        });

            var cultureToTest = "ru-RU"; // Set to "ru-RU" to enable russian. Set to "nl" for dutch

            // Comment the following line to use operating system default culture.
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureToTest);

            AchievementContext.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
            GuiInitializer.Initialize();

            var achievementDescriptorRepository = ObjectFactory.GetInstance<IAchievementRepository>();
            achievementDescriptorRepository.LoadFromAssembly(typeof(AnonymousObjectAchievement).Assembly);
            achievementDescriptorRepository.ResetAchievements();

            DetectionDispatcher.DetectionCompleted += DetectionDispatcher_DetectionCompleted;
            var file = System.IO.Path.GetFullPath("TestFile.cs");
            DetectionDispatcher.Dispatch(new BuildInformation()
            {
                ActiveFile = file,
                ChangedFiles = new string[] { file },
                CodeFiles = new string[] { file }
            });

            System.Console.Read();
        }

        private static void DetectionDispatcher_DetectionCompleted(object sender, DetectionCompletedEventArgs e)
        {
            System.Console.WriteLine(string.Format("{0} achievements tested in {1} milliseconds",
                e.AchievementsTested, e.ElapsedMilliseconds));
        }

        private static void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            System.Console.WriteLine("Unlocked: " + string.Join(", ", args.Achievements.Select(a => a.Name)));
        }
    }
}

#pragma warning restore