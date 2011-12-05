using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Service.Data;
using StructureMap;
using Strokes.Data;
using Strokes.Core.Service;
using Strokes.Service;
using Strokes.BasicAchievements.Achievements;
using Strokes.Core.Service.Model;

namespace Strokes.TreeViewTool
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ObjectFactory.Configure(a =>
            {
                a.For<IAchievementRepository>()
                 .Singleton()
                 .Use<AppDataXmlCompletedAchievementsRepository>()
                 .Ctor<string>("storageFile")
                 .Is("AchievementStorage_ConsoleTest.xml");

                a.For<IAchievementService>()
                 .Singleton()
                 .Use<SerialStrokesAchievementService>();
            });

            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            achievementService.LoadAchievementsFrom(typeof(ArrayLengthPropertyAchievement).Assembly);

            var achievements = achievementService.GetAllAchievements();

            var entryLevel = achievements.Where(x => x.DependsOn.Count == 0);
            foreach (var achievement in entryLevel)
            {
                PrintUnlocksAchievement(achievement, 0);
            }

            var manyDeps = achievements.Where(x => x.DependsOn.Count > 1);
            foreach (var a in manyDeps.OrderBy(x => x.DependsOn[0].Name))
            {
                Console.Write("\"{0}\" is unlocked by [ ", a.Name);
                foreach (var d in a.DependsOn)
                    Console.Write("\"{0}\" ", d.Name);
                Console.Write("]");
                Console.WriteLine("");
            }

            Console.Read();
        }

        static void PrintUnlocksAchievement(Achievement achievement, int depth)
        {
            for (int i = 0; i < depth; i++)
                Console.Write("\t");
            Console.WriteLine("- " + achievement.Name);
            
            foreach (var a in achievement.Unlocks)
            {
                PrintUnlocksAchievement(a, depth + 1);
            }
        }
    }
}
