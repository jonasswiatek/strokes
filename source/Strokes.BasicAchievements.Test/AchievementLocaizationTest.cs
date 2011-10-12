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
using Strokes.Core.Data;
using Strokes.Core.Data.Model;
using Strokes.Data;
using StructureMap;

namespace Strokes.BasicAchievements.Test
{
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\ru-RU", "ru-RU")]
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\nl", "nl")]
    [DeploymentItem(@"Strokes.BasicAchievements.Test\bin\Debug\da-DK", "da-DK")]
    [TestClass]
    public class AchievementLocaizationTest
    {
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

        //Comment in any of these to enable testing of these specific cultures
        /*[TestMethod]
        public void TestDutchCulture()
        {
            TestLocalizations(new CultureInfo("da-DK"));
        }

        [TestMethod]
        public void TestDanishCulture()
        {
            TestLocalizations(new CultureInfo("nl"));
        }*/

        private void TestLocalizations(CultureInfo cultureInfo)
        {
            ObjectFactory.Configure(a => a.For<IAchievementRepository>().Singleton().Use<AppDataXmlCompletedAchievementsRepository>());
            var achievementRepository = ObjectFactory.GetInstance<IAchievementRepository>();

            var assembly = typeof(ArrayLengthPropertyAchievement).Assembly;

            achievementRepository.LoadFromAssembly(assembly);

            var achievementResourcesType = assembly.GetType("Strokes.Resources.AchievementResources");
            var categoryResourcesType = assembly.GetType("Strokes.Resources.AchievementCategoryResources");

            var achievementResources = (ResourceManager)achievementResourcesType.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);
            var categoryResources = (ResourceManager)categoryResourcesType.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            //Lock to a specific localisation set
            var achievementResourceSet = achievementResources.GetResourceSet(cultureInfo, true, true);
            var categoryResourceSet = categoryResources.GetResourceSet(cultureInfo, true, true);

            var achievements = achievementRepository.GetAchievements();
            var achievementDescriptors = achievements.Select(a => (AchievementBase) Activator.CreateInstance(a.AchievementType)).Select(a => new
                                                                                                                                                 {
                                                                                                                                                     Descriptor = a.GetDescriptionAttribute(),
                                                                                                                                                     AchievementType = a.GetType()
                                                                                                                                                 }).ToList();
            
            foreach (var achievementDescriptor in achievementDescriptors)
            {
                var descriptor = achievementDescriptor.Descriptor;
                var achievementClassName = achievementDescriptor.AchievementType.Name;

                Assert.IsTrue(descriptor.AchievementTitle.StartsWith("@"), achievementClassName + ": AchievementTitle is not prefixed with @");
                Assert.IsTrue(descriptor.AchievementDescription.StartsWith("@"), achievementClassName + ": AchievementDescription is not prefixed with @");
                Assert.IsTrue(descriptor.AchievementCategory.StartsWith("@"), achievementClassName + ": AchievementCategory is not prefixed with @");

                var achievementTitle = achievementResourceSet.GetString(descriptor.AchievementTitle.Substring(1));
                var achievementDescription = achievementResourceSet.GetString(descriptor.AchievementDescription.Substring(1));
                var achievementCategory = categoryResourceSet.GetString(descriptor.AchievementCategory.Substring(1));
                
                Assert.IsNotNull(achievementTitle, achievementClassName + ": The key [" + descriptor.AchievementTitle + "] is not defined in RESX file");
                Assert.IsNotNull(achievementDescription, achievementClassName + ": The key [" + descriptor.AchievementDescription + "] is not defined in RESX file");
                Assert.IsNotNull(achievementCategory, achievementClassName + ": The key [" + descriptor.AchievementCategory + "] is not defined in RESX file");

                Assert.IsFalse(string.IsNullOrEmpty(achievementTitle), achievementClassName + ": The key [" + descriptor.AchievementTitle + "] is defined in RESX file, but it appears to be empty");
                Assert.IsFalse(string.IsNullOrEmpty(achievementDescription), achievementClassName + ": The key [" + descriptor.AchievementDescription + "] is defined in RESX file, but it appears to be empty");
                Assert.IsFalse(string.IsNullOrEmpty(achievementCategory), achievementClassName + ": The key [" + descriptor.AchievementCategory + "] is defined in RESX file, but it appears to be empty");
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
}