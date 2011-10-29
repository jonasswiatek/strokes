using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{76417EFA-1E80-45B5-A0A4-C065DD1E1649}", "@StringCompareAchievementName",
        AchievementDescription = "@StringCompareAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.string.compare.aspx",
        AchievementCategory = "@Strings")]
    public class StringCompareAchievement : AbstractSystemTypeUsage
    {
        public StringCompareAchievement() : base(typeof(System.String), "Compare")
        {
        }
    }

    [AchievementDescriptor("{FE01CF1A-6E39-4624-8FCD-9F104ACD40D8}", "@StringConcatAchievementName",
        AchievementDescription = "@StringConcatAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.string.concat.aspx",
        AchievementCategory = "@Strings")]
    public class StringConcatAchievement : AbstractSystemTypeUsage
    {
        public StringConcatAchievement() : base(typeof(System.String), "Concat")
        {
        }
    }

    [AchievementDescriptor("{106C10A9-8F87-49CC-8D61-7F233856CD49}", "@StringCopyAchievementName",
        AchievementDescription = "@StringCopyAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.string.copy.aspx",
        AchievementCategory = "@Strings")]
    public class StringCopyAchievement : AbstractSystemTypeUsage
    {
        public StringCopyAchievement() : base(typeof(System.String), "Copy")
        {
        }
    }

    [AchievementDescriptor("{AC08974F-9E7A-4B41-B778-D091789078F2}", "@StringEqualsAchievementName",
        AchievementDescription = "@StringEqualsAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.string.equals.aspx",
        AchievementCategory = "@Strings")]
    public class StringEqualsAchievement : AbstractSystemTypeUsage
    {
        public StringEqualsAchievement() : base(typeof(System.String), "Equals")
        {
        }
    }

    [AchievementDescriptor("{8C873AF8-BDEE-4793-ABC2-57449B109A7E}", "@StringJoinAchievementName",
        AchievementDescription = "@StringJoinAchievementDescription",
        AchievementCategory = "@Strings")]
    public class StringJoinAchievement : AbstractSystemTypeUsage
    {
        public StringJoinAchievement() : base(typeof(System.String), "Join")
        {
        }
    }
}
