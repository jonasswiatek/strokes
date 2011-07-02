using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Strokes.Core
{
    public class AchievementTracker
    {
        private static readonly List<Type> Achievements = new List<Type>();
        private static bool _loaded;

        /// <summary>
        /// Searches all assemblies for implementations of the Achievement class.
        /// 
        /// This method is cached internally and can be used excessively by external libraries.
        /// </summary>
        /// <returns>IList containing all concrete implementations of the Achievement class</returns>
        public static IList<Type> FindAllAchievementTypes()
        {
            if (!_loaded)
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var assemblyDirectorySegments = currentAssembly.Location.Split("\\".ToCharArray());
                var assemblyDirectory = "";
                for (var i = 0; !assemblyDirectorySegments[i].ToLower().EndsWith(".dll"); i++)
                {
                    assemblyDirectory += assemblyDirectorySegments[i] + "\\";
                }

                //Get all assemblies in this assemblies directory (this is where assemblies containing achievements will be located)
                var files = Directory.GetFiles(assemblyDirectory, "*.dll");
                foreach (var file in files)
                {
                    var assembly = Assembly.LoadFrom(file);
                    LoadAchievementsFromAssembly(assembly);
                }

                _loaded = true;
            }

            return Achievements;
        }

        /// <summary>
        /// Loads all Achievement-implementations from the pass assembly and tracks their progress
        /// </summary>
        /// <param name="assembly"></param>
        public static void LoadAchievementsFromAssembly(Assembly assembly)
        {
            if(assembly == null)
                throw new ArgumentNullException("assembly");

            var achievementsInAssembly = assembly.GetTypes().Where(a => a.BaseType == typeof (Achievement));
            foreach(var achievement in achievementsInAssembly)
            {
                if(!Achievements.Contains(achievement))
                    Achievements.Add(achievement);
            }
        }

        /// <summary>
        /// Returns all achievement descriptors available on the location system, including those in assemblies not originally shipped with the project.
        /// </summary>
        /// <returns>All achievement descriptors</returns>
        public static IEnumerable<AchievementDescriptionAttribute> GetAllAchievementDescriptors()
        {
            var achievementTypes = FindAllAchievementTypes();
            var completedAchievements = GetCompletedAchievements();
            foreach (var achievementType in achievementTypes)
            {
                var achievementDescriptors = achievementType.GetCustomAttributes(typeof(AchievementDescriptionAttribute), true);
                if (achievementDescriptors.Length == 1)
                {
                    var achievementDescriptor = (AchievementDescriptionAttribute)achievementDescriptors[0];

                    yield return achievementDescriptor;
                }
            }
        }

        public static void ResetAchievementProgress()
        {
            var userDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDir = Path.Combine(userDataDir, "CSharpAchiever");
            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            var appDataFile = Path.Combine(appDir, "achievements.xml");

            if(File.Exists(appDataFile))
                File.Delete(appDataFile);
        }

        /// <summary>
        /// Stores, in an XML file, that the passed achievement has been completed
        /// </summary>
        /// <param name="achievementDescriptor"></param>
        public static void RegisterAchievementCompleted(AchievementDescriptionAttribute achievementDescriptor)
        {
            var userDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDir = Path.Combine(userDataDir, "CSharpAchiever");
            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            var appDataFile = Path.Combine(appDir, "achievements.xml");
            XDocument document;

            if (File.Exists(appDataFile))
            {
                document = XDocument.Load(appDataFile);
            }
            else
            {
                document = new XDocument();
                document.AddFirst(new XElement("Achievements"));
            }

            if(!document.Descendants("Achievement").Any(a => a.Value == achievementDescriptor.AchievementTitle))
            {
                document.Root.Add(new XElement("Achievement")
                {
                    Value = achievementDescriptor.AchievementTitle
                });

                document.Save(appDataFile);
            }
        }

        /// <summary>
        /// Gets a list of strings of the fully qualified class names of achievements that have been completed.
        /// </summary>
        /// <returns>List of fully qualified class names of achievements completed</returns>
        public static IEnumerable<string> GetCompletedAchievements()
        {
            var userDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDir = Path.Combine(userDataDir, "CSharpAchiever");
            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            var appDataFile = Path.Combine(appDir, "achievements.xml");

            if (File.Exists(appDataFile))
            {
                var achievementsDocument = XDocument.Load(appDataFile);
                var achievements = achievementsDocument.Descendants("Achievement").Select(a => a.Value);
                return achievements;
            }

            return new List<string>();
        }
    }
}
