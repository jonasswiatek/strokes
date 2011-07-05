using System;
using System.Linq;

namespace Strokes.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class AchievementDescriptionAttribute : Attribute
    {
        public string AchievementTitle { get; private set; }
        public string AchievementDescription { get; set; }
        public string AchievementCategory { get; set; }

        /// <summary>
        /// ImageUri for an achievements image. This should refer to a resource within the assembly that specifies the achievement.
        /// </summary>
        public string ImageUri { get; set; }

        public AchievementDescriptionAttribute(string achievementTitle)
        {
            AchievementTitle = achievementTitle;
        }
    }
}
