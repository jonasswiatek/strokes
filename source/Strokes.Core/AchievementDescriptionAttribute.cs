using System;
using System.Linq;
using System.Resources;
using Strokes.Core.Properties;

namespace Strokes.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AchievementDescriptionAttribute : Attribute
    {
        private string description = string.Empty;
        private string category = string.Empty;
        private string title = string.Empty;

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
            get
            {
                if (title.StartsWith("@") && title.Length > 1)
                    return AchivementResources.ResourceManager.GetString(title.Substring(1));
                else
                    return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Gets or sets the achievement description.
        /// </summary>
        /// <value>The achievement description.</value>
        public string AchievementDescription
        {
            get
            {
                if (description.StartsWith("@") && description.Length > 1)
                    return AchivementResources.ResourceManager.GetString(description.Substring(1));
                else
                    return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Gets or sets the achievement category.
        /// </summary>
        /// <value>The achievement category.</value>
        public string AchievementCategory
        {
            get
            {
                if (category.StartsWith("@") && category.Length > 1)
                    return AchivementCategoryResources.ResourceManager.GetString(category.Substring(1));
                else
                    return category;
            }
            set
            {
                category = value;
            }
        }

        public string AchievementCategoryIdentifier
        {
            get
            {
                return category;
            }
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
        /// Initializes a new instance of the <see cref="AchievementDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="achievementTitle">The achievement title.</param>
        public AchievementDescriptionAttribute(string achievementTitle)
        {
            AchievementTitle = achievementTitle;
        }
    }
}
