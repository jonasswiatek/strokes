using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{76417EFA-1E80-45B5-A0A4-C065DD1E1649}", "@StringCompareAchievementName",
        AchievementDescription = "@StringCompareAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringCompareAchievement : AbstractMethodCall
    {
        public StringCompareAchievement() : base("String.Compare")
        {
        }
    }

    [AchievementDescriptor("{FE01CF1A-6E39-4624-8FCD-9F104ACD40D8}", "@StringConcatAchievementName",
        AchievementDescription = "@StringConcatAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringConcatAchievement : AbstractMethodCall
    {
        public StringConcatAchievement()
            : base("String.Concat")
        {
        }
    }

    [AchievementDescriptor("{106C10A9-8F87-49CC-8D61-7F233856CD49}", "@StringCopyAchievementName",
        AchievementDescription = "@StringCopyAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringCopyAchievement : AbstractMethodCall
    {
        public StringCopyAchievement()
            : base("String.Copy")
        {
        }
    }

    [AchievementDescriptor("{AC08974F-9E7A-4B41-B778-D091789078F2}", "@StringEqualsAchievementName",
        AchievementDescription = "@StringEqualsAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringEqualsAchievement : AbstractMethodCall
    {
        public StringEqualsAchievement()
            : base("String.Equals")
        {
        }
    }

    [AchievementDescriptor("{8C873AF8-BDEE-4793-ABC2-57449B109A7E}", "@StringJoinAchievementName",
        AchievementDescription = "@StringJoinAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringJoinAchievement : AbstractMethodCall
    {
        public StringJoinAchievement()
            : base("String.Join")
        {
        }
    }
}
