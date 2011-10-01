using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@ArrayClearMethodAchievementName",
        AchievementDescription = "@ArrayClearMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayClearMethodAchievement : AbstractMethodCall
    {
        public ArrayClearMethodAchievement() : base("System.Array.Clear")
        {
        }
    }

    [AchievementDescription("@ArrayIndexOfMethodAchievementName",
        AchievementDescription = "@ArrayIndexOfMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayIndexOfMethodAchievement : AbstractMethodCall
    {
        public ArrayIndexOfMethodAchievement()
            : base("System.Array.IndexOf")
        {
        }
    }

    [AchievementDescription("@ArrayReverseMethodAchievementName",
        AchievementDescription = "@ArrayReverseMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayReverseMethodAchievement : AbstractMethodCall
    {
        public ArrayReverseMethodAchievement()
            : base("System.Array.Reverse")
        {
        }
    }

    [AchievementDescription("@ArraySortMethodAchievementName",
        AchievementDescription = "@ArraySortMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArraySortMethodAchievement : AbstractMethodCall
    {
        public ArraySortMethodAchievement()
            : base("System.Array.Sort")
        {
        }
    }
}
