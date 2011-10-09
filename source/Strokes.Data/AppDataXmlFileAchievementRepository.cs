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
    public class AppDataXmlFileAchievementRepository : IAchievementRepository
    {
        private static readonly List<Achievement> Achievements = new List<Achievement>();
        private const string AchievementStorageDirectory = "Strokes for Visual Studio";
        private const string AchievementStorageFile = "AchievementStorage.xml";

        private static readonly List<CompletedAchievement> CompletedAchievements; 

        static AppDataXmlFileAchievementRepository()
        {
            CompletedAchievements = GetCompletedAchievements();
        }

        public IEnumerable<Achievement> GetAchievements()
        {
            foreach(var achievement in Achievements)
            {
                var achievementInstance = achievement;
                var completedAchievement = CompletedAchievements.FirstOrDefault(a => a.Guid == achievementInstance.Guid);
                if(completedAchievement != null)
                {
                    achievement.DateCompleted = completedAchievement.DateCompleted;
                    achievement.IsCompleted = completedAchievement.IsCompleted;
                }

                yield return achievement;
            }
        }

        public IEnumerable<Achievement> GetUnlockableAchievements()
        {
            var unlockedGuids = CompletedAchievements.Select(a => a.Guid);
            return Achievements.Where(a => !a.IsCompleted && a.DependsOn.All(b => unlockedGuids.Contains(b.Guid)));
        }

        public void MarkAchievementAsCompleted(Achievement achievementDescriptor)
        {
            // Used to update the GUI
            achievementDescriptor.DateCompleted = DateTime.Now;
            achievementDescriptor.IsCompleted = true;

            var completedAchievement = new CompletedAchievement(achievementDescriptor)
            {
                DateCompleted = DateTime.Now,
                IsCompleted = true
            };

            if(!CompletedAchievements.Contains(completedAchievement))
            {
                CompletedAchievements.Add(completedAchievement);
                PersistCompletedAchievements(); //Thread safety?
            }
        }

        public void LoadFromAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            var achievementsInAssembly = assembly.GetTypes().Where(a => IsAchievementDescendant(a.UnderlyingSystemType) && !a.IsAbstract);
            var achievementTypes = achievementsInAssembly.Select(achievement => (AchievementBase) Activator.CreateInstance(achievement)).ToList();
            var achievementDescriptors = achievementTypes.Select(achievement => achievement.GetDescriptionAttribute()).ToList();

            Achievements.AddRange(achievementTypes.Select(a => a.GetAchievementDto()));

            foreach(var achievement in Achievements)
            {
                var currentAchievement = achievement;
                var completedAchievement = CompletedAchievements.FirstOrDefault(a => a.Guid == currentAchievement.Guid);
                if (completedAchievement != null)
                {
                    currentAchievement.DateCompleted = completedAchievement.DateCompleted;
                    currentAchievement.IsCompleted = completedAchievement.IsCompleted;
                }
                var dependsOnGuids = achievementDescriptors.Where(a => a.Guid == currentAchievement.Guid).SelectMany(a => a.DependsOn ?? new string[]{});
                var unlocksGuids = achievementDescriptors.Where(a => a.DependsOn.Contains(currentAchievement.Guid)).Select(a => a.Guid);
                
                currentAchievement.DependsOn = Achievements.Where(a => dependsOnGuids.Contains(a.Guid));
                currentAchievement.Unlocks = Achievements.Where(a => unlocksGuids.Contains(a.Guid));
            }
        }

        public void ResetAchievements()
        {
            ResetCompletedAchievements();
        }

        private static bool IsAchievementDescendant(Type type)
        {
            if (type.BaseType == null)
                return false;

            var baseType = type;
            while (baseType.BaseType != null && baseType.BaseType != typeof(AchievementBase))
            {
                baseType = baseType.BaseType;
            }

            return baseType.BaseType == typeof(AchievementBase);
        }

        private static List<CompletedAchievement> GetCompletedAchievements()
        {
            var filename = GetAchievementStorageFile();

            if(!File.Exists(filename))
                return new List<CompletedAchievement>();

            using(var file = File.Open(filename, FileMode.OpenOrCreate)) //Ensure disposal of file handle
            {
                if(file.Length <= 0)
                    return new List<CompletedAchievement>();

                var serializer = new XmlSerializer(typeof(List<CompletedAchievement>));
                var completedAchievements = (List<CompletedAchievement>)serializer.Deserialize(file);

                return completedAchievements;
            }
        }

        private static void PersistCompletedAchievements()
        {
            if (AchievementContext.DisablePersist)
                return;

            var filename = GetAchievementStorageFile();

            using (var file = File.Open(filename, FileMode.Create)) //Ensure disposal of file handle
            {
                var serializer = new XmlSerializer(typeof(List<CompletedAchievement>));
                serializer.Serialize(file, CompletedAchievements);
            }
        }

        public void ResetCompletedAchievements()
        {
            CompletedAchievements.Clear();
            foreach(var achievement in Achievements) //Reset all cached completion data
            {
                achievement.IsCompleted = false;
                achievement.DateCompleted = default(DateTime);
            }

            var filename = GetAchievementStorageFile();

            if (File.Exists(filename))
                File.Delete(filename);
        }

        private static string GetAchievementStorageFile()
        {
            var userDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDir = Path.Combine(userDataDir, AchievementStorageDirectory);
            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            var appDataFile = Path.Combine(appDir, AchievementStorageFile);
            return appDataFile;
        }
    }
}