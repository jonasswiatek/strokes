using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Strokes.Core;
using Strokes.Core.Service.Model;
using Strokes.Service.Data;
using System.Globalization;

namespace Strokes.Data
{
    public class AppDataXmlCompletedAchievementsRepository
        : AppDataXmlFileRepositoryBase<List<CompletedAchievement>>, IAchievementRepository
    {
        private readonly List<Achievement> achievements = new List<Achievement>();
        private readonly List<CompletedAchievement> completedAchievements;
        private readonly Dictionary<Achievement, Type> achievementTypes = new Dictionary<Achievement, Type>();

        public AppDataXmlCompletedAchievementsRepository(string storageFile)
            : base(storageFile)
        {
            this.completedAchievements = Load() ?? new List<CompletedAchievement>();
        }

        public IEnumerable<Achievement> GetAchievements()
        {
            foreach (var achievement in achievements)
            {
                var achievementInstance = achievement;
                var completedAchievement = completedAchievements.FirstOrDefault(a => a.Guid == achievementInstance.Guid);

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
            var unlockedGuids = completedAchievements.Select(a => a.Guid);
            return achievements.Where(a => !a.IsCompleted && a.DependsOn.All(b => unlockedGuids.Contains(b.Guid)));
        }

        public void MarkAchievementAsCompleted(Achievement achievement)
        {
            achievement.DateCompleted = DateTime.Now;
            achievement.IsCompleted = true;

            var completedAchievement = new CompletedAchievement(achievement)
            {
                DateCompleted = DateTime.Now,
                IsCompleted = true
            };

            if (achievement.CodeOrigin != null)
            {
                completedAchievement.CodeSnapshot = achievement.CodeOrigin.GetCodeSnapshot();
                achievement.CodeSnapshot = completedAchievement.CodeSnapshot;
            }

            if (!completedAchievements.Contains(completedAchievement))
            {
                completedAchievements.Add(completedAchievement);
                PersistCompletedAchievements();
            }
        }

        public void UpdateLocalization(Achievement achievement, CultureInfo culture)
        {
            if (achievementTypes.ContainsKey(achievement))
            {
                var assemblyAchievement = achievementTypes[achievement];
                var achievementDto = assemblyAchievement.GetAchievementDto(culture);

                achievement.Name = achievementDto.Name;
                achievement.Category = achievementDto.Category;
                achievement.Description = achievementDto.Description;
            }
        }

        public void LoadFromAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            var achievementTypesInAssembly = assembly.GetTypes().Where
            (
                achievement => typeof(AchievementBase).IsAssignableFrom(achievement) && !achievement.IsAbstract
            );

            var assemblyAchievements = achievementTypesInAssembly.ToDictionary
            (
                x => x.GetAchievementDto(CultureInfo.CurrentCulture)
            );

            foreach (var kvp in assemblyAchievements)
                if (achievementTypes.ContainsKey(kvp.Key) == false)
                    achievementTypes.Add(kvp.Key, kvp.Value);

            var achievementDescriptors = achievementTypesInAssembly.Select(
                    achievement => achievement.GetDescriptionAttribute()).ToList();

            foreach (var achievement in assemblyAchievements.Keys)
            {
                var currentAchievement = achievement;
                var completedAchievement = completedAchievements.FirstOrDefault(a => a.Guid == currentAchievement.Guid);

                // Bind information from the persisted storage about this achievement 
                // (this is because it's been completed at an earlier time)
                if (completedAchievement != null)
                {
                    currentAchievement.DateCompleted = completedAchievement.DateCompleted;
                    currentAchievement.IsCompleted = completedAchievement.IsCompleted;
                    currentAchievement.CodeSnapshot = completedAchievement.CodeSnapshot;
                }

                var dependsOnGuids = achievementDescriptors
                        .Where(a => a.Guid == currentAchievement.Guid)
                        .SelectMany(a => a.DependsOn)
                        .ToList();

                var unlocksGuids = achievementDescriptors
                        .Where(a => a.DependsOn.Contains(currentAchievement.Guid))
                        .Select(a => a.Guid)
                        .ToList();

                currentAchievement.DependsOn = assemblyAchievements.Keys.Where(a => dependsOnGuids.Contains(a.Guid)).ToList();
                currentAchievement.Unlocks = assemblyAchievements.Keys.Where(a => unlocksGuids.Contains(a.Guid)).ToList();

                achievements.Add(currentAchievement);
            }
        }

        public void ResetAchievements()
        {
            completedAchievements.Clear();
            foreach (var achievement in achievements)
            {
                achievement.IsCompleted = false;
                achievement.DateCompleted = default(DateTime);
            }

            Erase();
        }

        private void PersistCompletedAchievements()
        {
            Save(completedAchievements);
        }
    }
}