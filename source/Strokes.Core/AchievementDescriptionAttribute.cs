using System;
using System.Linq;
namespace CSharpAchiever.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class AchievementDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Indicates that this achievement has been completed.
        /// This attribute is not meant to be configured by the implementing class, but is for internal use.
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                var achievements = AchievementTracker.GetCompletedAchievements();
                return achievements.Contains(AchievementTitle);
            }
        }
        public string AchievementTitle { get; private set; }
        public string AchievementDescription { get; set; }
        public string AchievementCategory { get; set; }

        public AchievementDescriptionAttribute(string achievementTitle)
        {
            AchievementTitle = achievementTitle;
        }
    }
}
