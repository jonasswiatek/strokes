using System.Collections.Generic;
using System.Linq;
using Strokes.Core.Service.Model;

namespace Strokes.Service.Data.Model
{
    public class AchievementCategory
    {
        public string CategoryName
        {
            get;
            set;
        }

        public IEnumerable<Achievement> Achievements
        {
            get;
            set;
        }
    }

    public static class AchievementDescriptorHelper
    {
        public static IEnumerable<AchievementCategory> AsCategories(this IEnumerable<Achievement> achievementDescriptors)
        {
            var categories = achievementDescriptors.Select(a => a.Category).Distinct().ToList();

            return achievementDescriptors
                        .Select(a => a.Category)
                        .Distinct()
                        .OrderBy(a => a)
                        .Select(b => new AchievementCategory()
                        {
                            CategoryName = b,
                            Achievements = achievementDescriptors.Where(a => a.Category == b).OrderBy(c => c.Name)
                        });
        }
    }
}
