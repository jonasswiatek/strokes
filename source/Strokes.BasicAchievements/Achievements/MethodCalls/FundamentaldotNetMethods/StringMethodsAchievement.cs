using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@StringCompareAchievementName",
        AchievementDescription = "@StringCompareAchievementDescription",
        AchievementCategory = "Strings")]
    public class StringCompareAchievement : AbstractMethodCall
    {
        public StringCompareAchievement() : base("String.Compare")
        {
        }
    }

    [AchievementDescription("@StringConcatAchievementName",
        AchievementDescription = "@StringConcatAchievementDescription",
        AchievementCategory = "Strings")]
    public class StringConcatAchievement : AbstractMethodCall
    {
        public StringConcatAchievement()
            : base("String.Concat")
        {
        }
    }

    [AchievementDescription("@StringCopyAchievementName",
        AchievementDescription = "@StringCopyAchievementDescription",
        AchievementCategory = "Strings")]
    public class StringCopyAchievement : AbstractMethodCall
    {
        public StringCopyAchievement()
            : base("String.Copy")
        {
        }
    }

    [AchievementDescription("@StringEqualsAchievementName",
        AchievementDescription = "@StringEqualsAchievementDescription",
        AchievementCategory = "Strings")]
    public class StringEqualsAchievement : AbstractMethodCall
    {
        public StringEqualsAchievement()
            : base("String.Equals")
        {
        }
    }

    [AchievementDescription("@StringJoinAchievementName",
        AchievementDescription = "@StringJoinAchievementDescription",
        AchievementCategory = "Strings")]
    public class StringJoinAchievement : AbstractMethodCall
    {
        public StringJoinAchievement()
            : base("String.Join")
        {
        }
    }
}
