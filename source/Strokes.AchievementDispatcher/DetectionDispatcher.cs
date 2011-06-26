using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.Core;
using Strokes.GUI;

namespace Strokes.AchievementDispatcher
{
    public class DetectionDispatcher
    {
        /// <summary>
        /// Dispatches handling of achievement detection in the file(s) specified in the passed BuildInformation object.
        /// 
        /// This method is detection method agnostic. It simply forwards the BuildInformation object to all implementations of the Achievement class.
        /// </summary>
        /// <param name="buildInformation">Objects specifying documents to parse for achievements.</param>
        public static bool Dispatch(BuildInformation buildInformation)
        {
            var detectionSession = new DetectionSession(buildInformation);
            var achievementTypes = AchievementTracker.FindAllAchievementTypes();

            var unlockedAchievements = new List<Achievement>();
            var completedAchievements = AchievementTracker.GetCompletedAchievements();
            foreach (var achievementType in achievementTypes)
            {
                var achievement = (Achievement)Activator.CreateInstance(achievementType);
                var descriptor = achievement.GetAchievementDescriptor();

                if (completedAchievements.Contains(descriptor.AchievementTitle)) //Skip if this achievement has already been completed
                    continue;
            
                var achievementUnlocked = achievement.DetectAchievement(detectionSession);

                if (achievementUnlocked)
                {
                    unlockedAchievements.Add(achievement);
                }
            }

            if(unlockedAchievements.Count() > 0)
            {
                DisplayAchievements(unlockedAchievements);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Dispatches an achievement on to the MainAchievement GUI
        /// </summary>
        /// <param name="achievements">Achievement to pass on</param>
        private static void DisplayAchievements(IEnumerable<Achievement> achievements)
        {
            MainAchievementGui.DisplayAchievements(achievements);
        }
    }
}