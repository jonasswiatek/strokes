using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{FAB140C9-B951-4600-BCCB-CE0AD93419D8}", "@ArrayClearMethodAchievementName",
        AchievementDescription = "@ArrayClearMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayClearMethodAchievement : AbstractMethodCall
    {
        public ArrayClearMethodAchievement() : base("Array.Clear")
        {
        }
    }

    [AchievementDescriptor("{F54D457D-8A8D-44C7-81AC-2E66FD894F25}", "@ArrayIndexOfMethodAchievementName",
        AchievementDescription = "@ArrayIndexOfMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayIndexOfMethodAchievement : AbstractMethodCall
    {
        public ArrayIndexOfMethodAchievement()
            : base("Array.IndexOf")
        {
        }
    }

    [AchievementDescriptor("{7C801797-1B66-41D8-A658-FCE84929D1CA}", "@ArrayReverseMethodAchievementName",
        AchievementDescription = "@ArrayReverseMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayReverseMethodAchievement : AbstractMethodCall
    {
        public ArrayReverseMethodAchievement()
            : base("Array.Reverse")
        {
        }
    }

    [AchievementDescriptor("{282C5488-C7CC-43E7-9F81-D44354B0794D}", "@ArraySortMethodAchievementName",
        AchievementDescription = "@ArraySortMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArraySortMethodAchievement : AbstractMethodCall
    {
        public ArraySortMethodAchievement()
            : base("Array.Sort")
        {
        }
    }
}
