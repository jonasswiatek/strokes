using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Clear an array", AchievementDescription = "Use the Array.Clear method to Clear an array", AchievementCategory = "Arrays")]
    public class ArrayClearMethodAchievement : AbstractMethodCall
    {
        public ArrayClearMethodAchievement() : base("System.Array.Clear")
        {
        }
    }

    [AchievementDescription("IndexOf an array", AchievementDescription = "Use the Array.IndexOf method to IndexOf an array", AchievementCategory = "Arrays")]
    public class ArrayIndexOfMethodAchievement : AbstractMethodCall
    {
        public ArrayIndexOfMethodAchievement()
            : base("System.Array.IndexOf")
        {
        }
    }

    [AchievementDescription("Reverse an array", AchievementDescription = "Use the Array.Reverse method to Reverse an array", AchievementCategory = "Arrays")]
    public class ArrayReverseMethodAchievement : AbstractMethodCall
    {
        public ArrayReverseMethodAchievement()
            : base("System.Array.Reverse")
        {
        }
    }

    [AchievementDescription("Sort an array", AchievementDescription = "Use the Array.Sort method to sort an array", AchievementCategory = "Arrays")]
    public class ArraySortMethodAchievement : AbstractMethodCall
    {
        public ArraySortMethodAchievement()
            : base("System.Array.Sort")
        {
        }
    }
}
