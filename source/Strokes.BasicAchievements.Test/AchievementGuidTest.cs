using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
namespace Strokes.BasicAchievements.Test
{
    [TestClass]
    public class AchievementGuidTest
    {
        [TestMethod]
        public void TestGuids()
        {
            var achievementAssembly = typeof(NRefactoryAchievement).Assembly;
            var achievementImplementations = achievementAssembly.GetTypes().Where(a => typeof (AchievementBase).IsAssignableFrom(a) && !a.IsAbstract);

            var usedGuids = new List<Guid>();
            foreach(var achievementType in achievementImplementations)
            {
                var attributes = achievementType.GetCustomAttributes(typeof (AchievementDescriptorAttribute), true);
                if(attributes.Length <= 0)
                    continue;

                var descriptorAttribute = (AchievementDescriptorAttribute)attributes[0];
                var guid = new Guid(descriptorAttribute.Guid);

                Assert.IsFalse(usedGuids.Contains(guid), "Duplicate GUID found in: " + achievementType.FullName);
                usedGuids.Add(guid);
            }

            Assert.IsTrue(usedGuids.Count > 0 && usedGuids.Count == achievementImplementations.Count(), "Number of achievements implemented does not match number of guids tested");
        }
    }
}