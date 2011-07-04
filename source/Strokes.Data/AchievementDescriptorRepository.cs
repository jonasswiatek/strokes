using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Strokes.Core;
using Strokes.Core.Contracts;
using Strokes.Core.Model;

namespace Strokes.Data
{
    public class AchievementDescriptorRepository : IAchievementDescriptorRepository 
    {
        private static readonly List<AchievementDescriptor> Achievements = new List<AchievementDescriptor>();
        private const string AchievementStorageDirectory = "Strokes for Visual Studio";
        private const string AchievementStorageFile = "AchievementStorage.xml";

        private static readonly List<CompletedAchievement> CompletedAchievements; 

        static AchievementDescriptorRepository()
        {
            CompletedAchievements = GetCompletedAchievements();
        }

        public IEnumerable<AchievementDescriptor> GetAll()
        {
            foreach(var achievement in Achievements)
            {
                var completedAchievement = CompletedAchievements.SingleOrDefault(a => a.Name == achievement.Name);
                if(completedAchievement != null)
                {
                    achievement.DateCompleted = completedAchievement.DateCompleted;
                    achievement.IsCompleted = completedAchievement.IsCompleted;
                }

                yield return achievement;
            }
        }

        public void MarkAchievementAsCompleted(Achievement achievement)
        {
            var achievementDescriptor = achievement.GetAchievementDescriptor();
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
            foreach (var achievement in achievementsInAssembly)
            {
                var achievementInstance = (Achievement) Activator.CreateInstance(achievement);
                var descriptor = achievementInstance.GetAchievementDescriptor();

                if (!Achievements.Contains(descriptor))
                    Achievements.Add(descriptor);
            }
        }

        private static bool IsAchievementDescendant(Type type)
        {
            if (type.BaseType == null)
                return false;

            var baseType = type;
            while (baseType.BaseType != null && baseType.BaseType != typeof(Achievement))
            {
                baseType = baseType.BaseType;
            }

            return baseType.BaseType == typeof(Achievement);
        }

        private static List<CompletedAchievement> GetCompletedAchievements()
        {
            var filename = GetAchievementStorageFile();

            if(!File.Exists(filename))
                return new List<CompletedAchievement>();

            using(var file = File.Open(filename, FileMode.OpenOrCreate)) //Ensure disposal of file handle
            {
                var serializer = new XmlSerializer(typeof(CompletedAchievement));
                var completedAchievements = (List<CompletedAchievement>)serializer.Deserialize(file);

                return completedAchievements;
            }
        }

        private static void PersistCompletedAchievements()
        {
            var filename = GetAchievementStorageFile();

            using (var file = File.Open(filename, FileMode.Create)) //Ensure disposal of file handle
            {
                var serializer = new XmlSerializer(typeof(CompletedAchievement));
                serializer.Serialize(file, CompletedAchievements);
            }
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