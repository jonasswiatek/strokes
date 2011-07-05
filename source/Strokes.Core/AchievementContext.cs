using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Model;

namespace Strokes.Core
{
    public static class AchievementContext
    {
        //Disables the persistance of unlocked achievements. Practical for testing.
        public static bool DisablePersist = true;

        public delegate void AchievementsUnlockedHandler(object sender, AchievementsUnlockedEventArgs args);
        public static event AchievementsUnlockedHandler AchievementsUnlocked;

        public static void OnAchievementsUnlocked(object sender, IEnumerable<AchievementDescriptor> unlockedAchievements)
        {
            if(AchievementsUnlocked != null)
            {
                AchievementsUnlocked(sender, new AchievementsUnlockedEventArgs {Achievements = unlockedAchievements});

            }
        }
    }

    public class AchievementsUnlockedEventArgs
    {
        public IEnumerable<AchievementDescriptor> Achievements;
    }
}
