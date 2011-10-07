using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;
using Strokes.Core.Model;
using System.Resources;
using System.Runtime.Serialization;
using System.Reflection;

namespace Strokes.Data
{
    public static class AchievementHelper
    {
        public static AchievementDescriptionAttribute GetDescriptionAttribute(this AchievementBase achievement)
        {
            var descriptionAttributes = achievement.GetType().GetCustomAttributes(typeof(AchievementDescriptionAttribute), true);
            
            if (descriptionAttributes.Length == 1)
            {
                return (AchievementDescriptionAttribute)descriptionAttributes[0];
            }

            if (descriptionAttributes.Length > 1)
            {
                throw new ArgumentException("Achievement class defines more than one AchievementDescriptionAttribute", "achievement");
            }

            throw new ArgumentException("Achievement class does not define an AchievementDescriptionAttribute", "achievement");
        }

        public static AchievementDescriptor GetAchievementDescriptor(this AchievementBase achievement)
        {
            var descriptionAttribute = GetDescriptionAttribute(achievement);
            var assembly = achievement.GetType().Assembly;

            var AchievementResourcesType = assembly.GetType("Strokes.Resources.AchievementResources");
            var categoryResourcesType = assembly.GetType("Strokes.Resources.AchievementCategoryResources");

            var AchievementResources = (ResourceManager)AchievementResourcesType.GetProperty("ResourceManager", 
                BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            var categoryResources = (ResourceManager)categoryResourcesType.GetProperty("ResourceManager", 
                BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            var category = descriptionAttribute.AchievementCategory;
            if (category.StartsWith("@") && category.Length > 1)
                category = categoryResources.GetString(category.Substring(1));

            var title = descriptionAttribute.AchievementTitle;
            if (title.StartsWith("@") && title.Length > 1)
                title = AchievementResources.GetString(title.Substring(1));

            var description = descriptionAttribute.AchievementDescription;
            if (description.StartsWith("@") && description.Length > 1)
                description = AchievementResources.GetString(description.Substring(1));

            var descriptor = new AchievementDescriptor
            {
                AchievementType = achievement.GetType(),
                Category = category,
                Description = description,
                Name = title,
                Image = descriptionAttribute.Image,
            };

            return descriptor;
        }
    }
}
