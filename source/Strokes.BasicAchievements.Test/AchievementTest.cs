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
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Data;
using Strokes.Core.Data.Model;
using Strokes.Data;
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
            ObjectFactory.Configure(a => a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>());
            var achievementRepository = ObjectFactory.GetInstance<IAchievementRepository>();
            achievementRepository.LoadFromAssembly(typeof(NRefactoryAchievement).Assembly);
        }

        [DeploymentItem(@"TestCases", "TestCases")]
        [TestMethod]
        public void TestAchievements()
        {
            const string achievementBaseNamespace = "Strokes.BasicAchievements.Test.";
            var achievementRepository = ObjectFactory.GetInstance<IAchievementRepository>();

            var achievementTests = GetType().Assembly.GetTypes().Where(a => a.GetCustomAttributes(typeof (ExpectUnlockAttribute), true).Length > 0);
            foreach(var test in achievementTests)
            {
                var testCasePath = test.FullName.Replace(achievementBaseNamespace, "").Replace(".", "/") + ".cs";
                var sourceFile = Path.GetFullPath(testCasePath);
                var buildInformation = new BuildInformation()
                                           {
                                               ActiveFile = sourceFile,
                                               ActiveProject = null,
                                               ActiveProjectOutputDirectory = Path.GetDirectoryName(sourceFile),
                                               ChangedFiles = new []{sourceFile},
                                               CodeFiles = new[] { sourceFile }
                                           };

                var expectedAchievements = test.GetCustomAttributes(typeof(ExpectUnlockAttribute), true).Select(a => ((ExpectUnlockAttribute)a).ExpectedAchievementType).ToList();

                using (var detectionSession = new DetectionSession(buildInformation))
                {
                    var achievements = achievementRepository.GetAchievements().ToList();

                    var tasks = new Task[achievements.Count()];
                    var i = 0;

                    var padLock = new object();
                    var unlockedAchievements = new ConcurrentBag<Type>();
                    
                    foreach (var uncompletedAchievement in achievements)
                    {
                        var a = uncompletedAchievement;

                        tasks[i++] = Task.Factory.StartNew(() =>
                                                               {
                                                                    var achievementType = a.AchievementType;
                                                                    var achievement = (AchievementBase)Activator.CreateInstance(achievementType);

                                                                    var achievementUnlocked = achievement.DetectAchievement(detectionSession);

                                                                    if (achievementUnlocked)
                                                                    {
                                                                        a.CodeLocation = achievement.AchievementCodeLocation;
                                                                        a.IsCompleted = true;
                                                                        unlockedAchievements.Add(achievementType);
                                                                    }
                                                                });
                    }

                    Task.WaitAll(tasks);

                    //Test that expected achievements unlocked
                    foreach(var expectedAchievement in expectedAchievements)
                    {
                        Assert.IsTrue(unlockedAchievements.Contains(expectedAchievement), Path.GetFileName(sourceFile) + " did not unlock expected achievement: " + expectedAchievement.FullName);
                    }

                    //Test that only expected achievements unlocked
                    var unexpectedAchievements = unlockedAchievements.Except(expectedAchievements).Except(_globallyIgnoredAchievements).ToList();
                    Assert.IsTrue(unexpectedAchievements.Count() == 0, Path.GetFileName(sourceFile) + " unlocks unexpected achievements: " + string.Join(", ", unexpectedAchievements.Select(a => a.FullName)));
                }
            }
        }

        [TestMethod]
        public void TestCoverage()
        {
            var achievementRepository = ObjectFactory.GetInstance<IAchievementRepository>();
            var achievementImplementations = achievementRepository.GetAchievements().Select(a => a.AchievementType);

            var achievementTests = GetType().Assembly.GetTypes().Where(a => a.GetCustomAttributes(typeof (ExpectUnlockAttribute), true).Length > 0);
            var testedAchievementImplementations = achievementTests.SelectMany(a => a.GetCustomAttributes(typeof (ExpectUnlockAttribute), true).Select(b => (ExpectUnlockAttribute)b).Select(c => c.ExpectedAchievementType)).Distinct();
            var untestedAchievements = achievementImplementations.Except(testedAchievementImplementations);

            Assert.IsFalse(untestedAchievements.Any(), "The following achievements (" + untestedAchievements.Count() + ") are untested:\r\n" + string.Join("\r\n", untestedAchievements.Select(a => a.Name)));
        }
    }
}