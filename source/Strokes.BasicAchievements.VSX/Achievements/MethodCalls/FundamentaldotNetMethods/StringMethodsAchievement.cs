using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("String comparing", AchievementDescription = "Use the String.Compare method", AchievementCategory = "Strings")]
    public class StringCompareAchievement : AbstractMethodCall
    {
        public StringCompareAchievement() : base("System.String.Compare")
        {
        }
    }

    [AchievementDescription("String concaten-what?", AchievementDescription = "Use the String.Concat method", AchievementCategory = "Strings")]
    public class StringConcatAchievement : AbstractMethodCall
    {
        public StringConcatAchievement()
            : base("System.String.Concat")
        {
        }
    }

    [AchievementDescription("String copying", AchievementDescription = "Use the String.Copy method", AchievementCategory = "Strings")]
    public class StringCopyAchievement : AbstractMethodCall
    {
        public StringCopyAchievement()
            : base("System.String.Copy")
        {
        }
    }

    [AchievementDescription("String equals", AchievementDescription = "Use the String.Equals method", AchievementCategory = "Strings")]
    public class StringEqualsAchievement : AbstractMethodCall
    {
        public StringEqualsAchievement()
            : base("System.String.Equals")
        {
        }
    }

    [AchievementDescription("String joining", AchievementDescription = "Use the String.Join method", AchievementCategory = "Strings")]
    public class StringJoinAchievement : AbstractMethodCall
    {
        public StringJoinAchievement()
            : base("System.String.Join")
        {
        }
    }
}
