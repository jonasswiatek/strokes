using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Data.Model;

namespace Strokes.Core
{
    public delegate void AchievementsUnlockedHandler(object sender, AchievementsUnlockedEventArgs args);

    public static class AchievementContext
    {
        public static bool DisablePersist = false;

        public static event AchievementsUnlockedHandler AchievementsUnlocked;

        public static void OnAchievementsUnlocked(object sender, IEnumerable<Achievement> unlockedAchievements)
        {
            if (AchievementsUnlocked != null)
            {
                AchievementsUnlocked(sender, new AchievementsUnlockedEventArgs
                {
                    Achievements = unlockedAchievements
                });
            }
        }

        public static event EventHandler AchievementDetectionStarting;

        public static void OnAchievementDetectionStarting(object sender, EventArgs e)
        {
            if (AchievementDetectionStarting != null)
            {
                AchievementDetectionStarting(sender, e);
            }
        }
    }

    public class AchievementsUnlockedEventArgs
    {
        public IEnumerable<Achievement> Achievements
        {
            get;
            set;
        }
    }
}
