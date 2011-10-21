using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Data;
using Strokes.Service;
using Strokes.Service.Data;
using StructureMap;

namespace Strokes.BasicAchievements.Test
{
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\ru-RU", "ru-RU")]
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\nl", "nl")]
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\da-DK", "da-DK")]
    [TestClass]
    public class AchievementLocaizationTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectFactory.Configure(a =>
            {
                a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>().Ctor<string>("storageFile").Is("AchievementStorage_UnitTest_LocalizationTest.xml");
                a.For<IAchievementService>().Singleton().Use<ParallelStrokesAchievementService>();
            });

            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            achievementService.LoadAchievementsFrom(typeof(ArrayLengthPropertyAchievement).Assembly);
        }

        [TestMethod]
        public void TestDefaultCulture()
        {
            TestLocalizations(CultureInfo.InvariantCulture);
        }
        
        [TestMethod]
        public void TestRussianCulture()
        {
            TestLocalizations(new CultureInfo("ru-RU"));
        }

        private static void TestLocalizations(CultureInfo cultureInfo)
        {
            var achievementService = ObjectFactory.GetInstance<IAchievementService>();

            var assembly = typeof (ArrayLengthPropertyAchievement).Assembly;
            var achievementResourcesType = assembly.GetType("Strokes.Resources.AchievementResources");
            var categoryResourcesType = assembly.GetType("Strokes.Resources.AchievementCategoryResources");

            var achievementResources = (ResourceManager)achievementResourcesType.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);
            var categoryResources = (ResourceManager)categoryResourcesType.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            //Lock to a specific localisation set
            var achievementResourceSet = achievementResources.GetResourceSet(cultureInfo, true, true);
            var categoryResourceSet = categoryResources.GetResourceSet(cultureInfo, true, true);

            var achievements = achievementService.GetAllAchievements();
            var achievementDescriptors = achievements.Select(a => (StaticAnalysisAchievementBase) Activator.CreateInstance(a.AchievementType)).Select(a => new
                                                                                                                                                 {
                                                                                                                                                     Descriptor = a.GetDescriptionAttribute(),
                                                                                                                                                     AchievementType = a.GetType()
                                                                                                                                                 }).ToList();


            var missingLocalizations = new Dictionary<string, List<string>>();

            foreach (var achievementDescriptor in achievementDescriptors)
            {
                var descriptor = achievementDescriptor.Descriptor;
                var achievementClassName = achievementDescriptor.AchievementType.FullName;
                
                var missingKeys = new List<string>();

                Assert.IsTrue(descriptor.AchievementTitle.StartsWith("@"), achievementClassName + ": AchievementTitle is not prefixed with @");
                Assert.IsTrue(descriptor.AchievementDescription.StartsWith("@"), achievementClassName + ": AchievementDescription is not prefixed with @");
                Assert.IsTrue(descriptor.AchievementCategory.StartsWith("@"), achievementClassName + ": AchievementCategory is not prefixed with @");

                var achievementTitle = achievementResourceSet.GetString(descriptor.AchievementTitle.Substring(1));
                var achievementDescription = achievementResourceSet.GetString(descriptor.AchievementDescription.Substring(1));
                var achievementCategory = categoryResourceSet.GetString(descriptor.AchievementCategory.Substring(1));

                if (string.IsNullOrEmpty(achievementTitle))
                {
                    missingKeys.Add("AchievementTitle: " + descriptor.AchievementTitle);
                }
                if (string.IsNullOrEmpty(achievementDescription))
                {
                    missingKeys.Add("AchievementDescription: " + descriptor.AchievementDescription);
                }
                if (string.IsNullOrEmpty(achievementCategory))
                {
                    missingKeys.Add("AchievementCategory: " + descriptor.AchievementCategory);
                }

                if(missingKeys.Count > 0)
                {
                    missingLocalizations.Add(achievementClassName, missingKeys);
                }
            }

            if(missingLocalizations.Count > 0)
            {
                var logString = "";
                foreach(var missingLocalization in missingLocalizations)
                {
                    logString += missingLocalization.Key + ":\r\n\t" + string.Join("\r\n\t", missingLocalization.Value) + "\r\n\r\n";
                }
                Assert.Fail("The following keys are not defined in the RESX file(s) for \"" + cultureInfo.Name + "\":\r\n\r\n" + logString);
            }

            foreach(System.Collections.DictionaryEntry entry in achievementResourceSet)
            {
                var key = entry.Key;
                var isAchievementTitle = achievementDescriptors.Any(a => a.Descriptor.AchievementTitle == "@" + key);
                var isAchievementDescription = achievementDescriptors.Any(a => a.Descriptor.AchievementDescription == "@" + key);

                Assert.IsTrue(isAchievementTitle || isAchievementDescription, "Resource file defines unused key: [" + key + "]");
            }
        }
    }

    public class MissingLocalization
    {
        public string Achievement { get; set; }
        public List<string> Keys { get; set; }
    }
}