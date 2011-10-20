using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Challenges;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Data;
using Strokes.Service;
using Strokes.Service.Data;
using StructureMap;

namespace Strokes.BasicAchievements.Test
{
    [TestClass]
    public class AchievementTest
    {
        private readonly Type[] _globallyIgnoredAchievements = new []
                                                                {
                                                                    typeof(TypeOfAchievement),
                                                                    typeof(CreateClassAchievement),
                                                                    typeof(CreateMethodReturnVoidAchievement),
                                                                    typeof(CreateMethodAchievement)
                                                                };
        [TestInitialize]
        public void Initialize()
        {
            ObjectFactory.Configure(a =>
                                        {
                                            a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>();
                                            a.For<IAchievementService>().Singleton().Use<ParallelStrokesAchievementService>();
                                        });

            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            achievementService.LoadAchievementsFrom(typeof(ArrayLengthPropertyAchievement).Assembly);
        }

        [DeploymentItem(@"TestCases", "TestCases")]
        [TestMethod]
        public void TestAchievements()
        {
            const string achievementBaseNamespace = "Strokes.BasicAchievements.Test.";
            var achievementService = ObjectFactory.GetInstance<IAchievementService>();

            var achievementTests = GetType().Assembly.GetTypes().Where(a => a.GetCustomAttributes(typeof(ExpectUnlockAttribute), false).Length > 0);
            foreach(var test in achievementTests)
            {
                var testCasePath = test.FullName.Replace(achievementBaseNamespace, "").Replace(".", "/") + ".cs";
                var sourceFile = Path.GetFullPath(testCasePath);
                var buildInformation = new StaticAnalysisManifest()
                                           {
                                               ActiveFile = sourceFile,
                                               ActiveProject = null,
                                               ActiveProjectOutputDirectory = Path.GetDirectoryName(sourceFile),
                                               ChangedFiles = new []{sourceFile},
                                               CodeFiles = new[] { sourceFile }
                                           };

                var expectedAchievements = test.GetCustomAttributes(typeof(ExpectUnlockAttribute), false).Select(a => ((ExpectUnlockAttribute)a).ExpectedAchievementType).ToList();

                using (var detectionSession = new StatisAnalysisSession(buildInformation))
                {
                    var achievements = achievementService.GetAllAchievements().ToList();

                    var tasks = new Task[achievements.Count()];
                    var i = 0;

                    var unlockedAchievements = new ConcurrentBag<Type>();
                    foreach (var uncompletedAchievement in achievements)
                    {
                        var a = uncompletedAchievement;

                        tasks[i++] = Task.Factory.StartNew(() =>
                                                               {
                                                                    var achievementType = a.AchievementType;
                                                                    var achievement = (StaticAnalysisAchievementBase)Activator.CreateInstance(achievementType);

                                                                    var achievementUnlocked = achievement.IsAchievementUnlocked(detectionSession);

                                                                    if (achievementUnlocked)
                                                                    {
                                                                        a.CodeOrigin = achievement.AchievementCodeOrigin;
                                                                        a.IsCompleted = true;
                                                                        unlockedAchievements.Add(achievementType);
                                                                    }
                                                                });
                    }

                    Task.WaitAll(tasks);

                    //Test that expected achievements unlocked
                    foreach(var expectedAchievement in expectedAchievements)
                    {
                        Assert.IsTrue(unlockedAchievements.Contains(expectedAchievement), Path.GetFileName(sourceFile) + " did not unlock expected achievement: " + expectedAchievement.Name);
                    }

                    //Test that only expected achievements unlocked
                    var unexpectedAchievements = unlockedAchievements.Except(expectedAchievements).Except(_globallyIgnoredAchievements).ToList();
                    Assert.IsTrue(unexpectedAchievements.Count() == 0, Path.GetFileName(sourceFile) + " unlocks unexpected achievements: " + string.Join(", ", unexpectedAchievements.Select(a => a.Name)));
                }
            }
        }

        [TestMethod]
        public void TestCoverage()
        {
            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            var achievementImplementations = achievementService.GetAllAchievements().Select(a => a.AchievementType).Where(a => !typeof(Challenge).IsAssignableFrom(a)); //Ignore Challenges in this context - those are not unit testable from this project

            var achievementTests = GetType().Assembly.GetTypes().Where(a => a.GetCustomAttributes(typeof (ExpectUnlockAttribute), true).Length > 0);
            var testedAchievementImplementations = achievementTests.SelectMany(a => a.GetCustomAttributes(typeof (ExpectUnlockAttribute), true).Select(b => (ExpectUnlockAttribute)b).Select(c => c.ExpectedAchievementType)).Distinct();
            var untestedAchievements = achievementImplementations.Except(testedAchievementImplementations);

            Assert.IsFalse(untestedAchievements.Any(), "The following achievements (" + untestedAchievements.Count() + ") are untested:\r\n" + string.Join("\r\n", untestedAchievements.Select(a => a.Name)));
        }
    }
}