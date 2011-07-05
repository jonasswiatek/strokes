using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;
using Strokes.Core.Model;

namespace Strokes.Data
{
    public static class AchievementHelper
    {
        public static AchievementDescriptionAttribute GetDescriptionAttribute(this Achievement achievement)
        {
            var descriptionAttributes = achievement.GetType().GetCustomAttributes(typeof (AchievementDescriptionAttribute), true);
            if(descriptionAttributes.Length == 1)
            {
                return (AchievementDescriptionAttribute)descriptionAttributes[0];
            }
            
            if (descriptionAttributes.Length > 1)
            {
                throw new ArgumentException("Achievement class defines more than one AchievementDescriptionAttribute", "achievement");
            }

            throw new ArgumentException("Achievement class does not define an AchievementDescriptionAttribute", "achievement");
        }

        public static AchievementDescriptor GetAchievementDescriptor(this Achievement achievement)
        {
            var descriptionAttribute = GetDescriptionAttribute(achievement);
            return new AchievementDescriptor
                       {
                           AchievementType = achievement.GetType(),
                           Category = descriptionAttribute.AchievementCategory,
                           Description = descriptionAttribute.AchievementDescription,
                           Name = descriptionAttribute.AchievementTitle,
                           ImageUri = descriptionAttribute.ImageUri
                       };
        } 
    }
}
