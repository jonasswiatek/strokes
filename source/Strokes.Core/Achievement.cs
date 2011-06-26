using System;

namespace Strokes.Core
{
    public abstract class Achievement
    {
        public abstract bool DetectAchievement(DetectionSession detectionSession);

        public AchievementDescriptionAttribute GetAchievementDescriptor()
        {
            var achievementDescriptors = GetType().GetCustomAttributes(typeof(AchievementDescriptionAttribute), true);
            if (achievementDescriptors.Length == 1) /* There cannot be more of these, it's either zero or one because AllowMultiple is set to false */
            {
                var achievementDescriptor = (AchievementDescriptionAttribute)achievementDescriptors[0]; //This is safe
                return achievementDescriptor;
            }

            throw new Exception("Achievement does not specify an AchievementDescriptionAttribute");
        }
    }
}