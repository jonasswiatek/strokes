using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{FAB140C9-B951-4600-BCCB-CE0AD93419D8}", "@ArrayClearMethodAchievementName",
        AchievementDescription = "@ArrayClearMethodAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.array.aspx",
        AchievementCategory = "@Arrays")]
    public class ArrayClearMethodAchievement : AbstractSystemTypeUsage
    {
        public ArrayClearMethodAchievement() : base(typeof(System.Array), "Clear")
        {
        }
    }

    [AchievementDescriptor("{F54D457D-8A8D-44C7-81AC-2E66FD894F25}", "@ArrayIndexOfMethodAchievementName",
        AchievementDescription = "@ArrayIndexOfMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayIndexOfMethodAchievement : AbstractSystemTypeUsage
    {
        public ArrayIndexOfMethodAchievement() : base(typeof(System.Array), "IndexOf")
        {
        }
    }

    [AchievementDescriptor("{7C801797-1B66-41D8-A658-FCE84929D1CA}", "@ArrayReverseMethodAchievementName",
        AchievementDescription = "@ArrayReverseMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayReverseMethodAchievement : AbstractSystemTypeUsage
    {
        public ArrayReverseMethodAchievement() : base(typeof(System.Array), "Reverse")
        {
        }
    }

    [AchievementDescriptor("{282C5488-C7CC-43E7-9F81-D44354B0794D}", "@ArraySortMethodAchievementName",
        AchievementDescription = "@ArraySortMethodAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArraySortMethodAchievement : AbstractSystemTypeUsage
    {
        public ArraySortMethodAchievement() : base(typeof(System.Array), "Sort")
        {
        }
    }
}
