using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Strokes.Core;
using Strokes.Core.Data;
using Strokes.Core.Data.Model;

namespace Strokes.Data
{
    public class AppDataXmlCompletedAchievementsRepository : AppDataXmlFileRepositoryBase<List<CompletedAchievement>>, IAchievementRepository
    {
        private readonly List<Achievement> _achievements = new List<Achievement>();
        private readonly List<CompletedAchievement> _completedAchievements;

        public AppDataXmlCompletedAchievementsRepository() : base("AchievementStorage.xml")
        {
            _completedAchievements = Load();
        }

        public IEnumerable<Achievement> GetAchievements()
        {
            foreach (var achievement in _achievements)
            {
                var achievementInstance = achievement;
                var completedAchievement = _completedAchievements.FirstOrDefault(a => a.Guid == achievementInstance.Guid);

                if (completedAchievement != null)
                {
                    achievement.DateCompleted = completedAchievement.DateCompleted;
                    achievement.IsCompleted = completedAchievement.IsCompleted;
                }

                yield return achievement;
            }
        }

        public IEnumerable<Achievement> GetUnlockableAchievements()
        {
            var unlockedGuids = _completedAchievements.Select(a => a.Guid);
            return _achievements.Where(a => !a.IsCompleted && a.DependsOn.All(b => unlockedGuids.Contains(b.Guid)));
        }

        public void MarkAchievementAsCompleted(Achievement achievementDescriptor)
        {
            achievementDescriptor.DateCompleted = DateTime.Now;
            achievementDescriptor.IsCompleted = true;

            var completedAchievement = new CompletedAchievement(achievementDescriptor)
            {
                DateCompleted = DateTime.Now,
                IsCompleted = true
            };

            if (!_completedAchievements.Contains(completedAchievement))
            {
                _completedAchievements.Add(completedAchievement);
                PersistCompletedAchievements();
            }
        }

        public void LoadFromAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            var achievementsInAssembly = assembly.GetTypes().Where(a => typeof(AchievementBase).IsAssignableFrom(a) && !a.IsAbstract);
            var achievementTypes = achievementsInAssembly.Select(achievement => (AchievementBase)Activator.CreateInstance(achievement)).ToList();
            var achievementDescriptors = achievementTypes.Select(achievement => achievement.GetDescriptionAttribute()).ToList();

            _achievements.AddRange(achievementTypes.Select(a => a.GetAchievementDto()));

            foreach (var achievement in _achievements)
            {
                var currentAchievement = achievement;
                var completedAchievement = _completedAchievements.FirstOrDefault(a => a.Guid == currentAchievement.Guid);

                if (completedAchievement != null)
                {
                    currentAchievement.DateCompleted = completedAchievement.DateCompleted;
                    currentAchievement.IsCompleted = completedAchievement.IsCompleted;
                }

                var dependsOnGuids = achievementDescriptors
                        .Where(a => a.Guid == currentAchievement.Guid)
                        .SelectMany(a => a.DependsOn ?? new string[] { })
                        .ToList();

                var unlocksGuids = achievementDescriptors
                        .Where(a => a.DependsOn.Contains(currentAchievement.Guid))
                        .Select(a => a.Guid)
                        .ToList();

                currentAchievement.DependsOn = _achievements.Where(a => dependsOnGuids.Contains(a.Guid)).ToList();
                currentAchievement.Unlocks = _achievements.Where(a => unlocksGuids.Contains(a.Guid)).ToList();
            }
        }

        public void ResetAchievements()
        {
            _completedAchievements.Clear();
            foreach (var achievement in _achievements)
            {
                achievement.IsCompleted = false;
                achievement.DateCompleted = default(DateTime);
            }

            Erase();
        }

        private void PersistCompletedAchievements()
        {
            if (AchievementContext.DisablePersist)
                return;

            Save(_completedAchievements);
        }
    }
}