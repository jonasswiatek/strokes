using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.FeatureAchievements.IdeIntegration;

namespace Strokes.BasicAchievements.Test
{
    [TestClass]
    public class AchievementGuidTest
    {
        [TestMethod]
        public void TestGuids()
        {
            var achievementAssemblies = new[] {typeof (NRefactoryAchievement).Assembly, typeof (IdeIntegrationAchievement).Assembly};
            var achievementTypes = new List<Type>();

            foreach(var assembly in achievementAssemblies)
            {
                var assemblyAchievementTypes = assembly.GetTypes().Where(a => typeof(AchievementBase).IsAssignableFrom(a) && !a.IsAbstract).ToList();
                achievementTypes.AddRange(assemblyAchievementTypes);
            }

            var achievementDescriptors = achievementTypes.Select(a => new
                                                                        {
                                                                            Descriptor = a.GetDescriptionAttribute(),
                                                                            AchievementType = a
                                                                        }).ToList();

            var usedGuids = new List<Guid>();
            foreach (var achievementDescriptor in achievementDescriptors)
            {
                var currentAchievementDescriptor = achievementDescriptor.Descriptor;
                var currentAchevementType = achievementDescriptor.AchievementType;

                //Test if guid is set and valid.
                Guid guid;
                Assert.IsTrue(Guid.TryParse(currentAchievementDescriptor.Guid, out guid), "Invalid guid in " + currentAchevementType.FullName);
                
                //Test if the guid is unique
                Assert.IsFalse(usedGuids.Contains(guid), "Duplicate GUID found in: " + currentAchevementType.FullName);
                usedGuids.Add(guid);

                //Test for circular dependencies
                var dependencies = currentAchievementDescriptor.DependsOn;
                foreach(var dependency in dependencies)
                {
                    var currentDependency = dependency;
                    Assert.IsTrue(achievementDescriptors.Any(a => a.Descriptor.Guid == currentDependency), currentAchevementType.FullName + " depends on a guid that does not exist");

                    var dependencyDescriptor = achievementDescriptors.Single(a => a.Descriptor.Guid == currentDependency);
                    if (dependencyDescriptor.Descriptor.DependsOn == null)
                        continue;

                    Assert.IsFalse(dependencyDescriptor.Descriptor.DependsOn.Contains(currentAchievementDescriptor.Guid),
                        currentAchevementType.FullName + " has circular dependencies with "+ dependencyDescriptor.AchievementType.FullName);
                }
            }

            Assert.IsTrue(usedGuids.Count > 0 && usedGuids.Count == achievementTypes.Count(), 
                "Number of achievements implemented does not match number of guids tested");
        }
    }
}