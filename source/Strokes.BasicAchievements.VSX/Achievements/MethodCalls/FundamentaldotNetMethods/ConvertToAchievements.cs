using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@ConvertToCharAchievementName",
        AchievementDescription = "@ConvertToCharAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToCharAchievement : AbstractMethodCall
    {
        public ConvertToCharAchievement() : base("System.Convert.ToChar")
        {
        }
    }

    [AchievementDescription("@ConvertToDecimalAchievementName",
        AchievementDescription = "@ConvertToDecimalAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToDecimalAchievement : AbstractMethodCall
    {
        public ConvertToDecimalAchievement()
            : base("System.Convert.ToDecimal")
        {
        }
    }

    [AchievementDescription("@ConvertToDoubleAchievementName",
        AchievementDescription = "@ConvertToDoubleAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToDoubleAchievement : AbstractMethodCall
    {
        public ConvertToDoubleAchievement()
            : base("System.Convert.ToDouble")
        {
        }
    }

    [AchievementDescription("@ConvertToInt32AchievementName",
        AchievementDescription = "@ConvertToInt32AchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToInt32Achievement : AbstractMethodCall
    {
        public ConvertToInt32Achievement()
            : base("System.Convert.ToInt32")
        {
        }
    }
}
