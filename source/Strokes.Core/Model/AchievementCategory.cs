using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core.Model
{
    public class AchievementCategory
    {
        public string CategoryName { get; set; }
        public IEnumerable<AchievementDescriptor> Achievements;
    }

    public static class AchievementDescriptorHelper
    {
        public static IEnumerable<AchievementCategory> AsCategories(this IEnumerable<AchievementDescriptor> achievementDescriptors)
        {
            var categories = achievementDescriptors.Select(a => a.Category).Distinct().OrderBy(a => a).Select(b => new AchievementCategory()
                                                                                                                    {
                                                                                                                        CategoryName = b,
                                                                                                                        Achievements = achievementDescriptors.Where(a => a.Category == b).OrderBy(c => c.Name)
                                                                                                                    });

            return categories;
        }
    }
}
