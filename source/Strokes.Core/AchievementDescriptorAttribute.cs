using System;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Reflection;

namespace Strokes.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AchievementDescriptorAttribute : Attribute
    {
        public string Guid
        {
            get; 
            private set;
        }

        public string[] DependsOn { get; set; }

        /// <summary>
        /// Point to an achievement type that must be completed prior to this unlocking
        /// </summary>
        public Type ParentAchievement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the achievement title.
        /// </summary>
        /// <value>The achievement title.</value>
        public string AchievementTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the achievement description.
        /// </summary>
        /// <value>The achievement description.</value>
        public string AchievementDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the achievement category.
        /// </summary>
        /// <value>The achievement category.</value>
        public string AchievementCategory
        {
            get;
            set;
        }

        /// <summary>
        /// Image for an achievements image. 
        /// </summary>
        /// <remarks>
        /// This should refer to a resource within the assembly that specifies the achievement.
        /// </remarks>
        public string Image
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AchievementDescriptorAttribute"/> class.
        /// </summary>
        /// <param name="achievementTitle">The achievement title.</param>
        public AchievementDescriptorAttribute(string guid, string achievementTitle)
        {
            Guid = guid;
            AchievementTitle = achievementTitle;
        }
    }
}
