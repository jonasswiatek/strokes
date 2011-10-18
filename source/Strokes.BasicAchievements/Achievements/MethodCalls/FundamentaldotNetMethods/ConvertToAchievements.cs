using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{349D23BD-D117-4095-9A2E-381090EC2A51}", "@ConvertToCharAchievementName",
        AchievementDescription = "@ConvertToCharAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToCharAchievement : AbstractMethodCall
    {
        public ConvertToCharAchievement() : base("System.Convert.ToChar")
        {
        }
    }

    [AchievementDescriptor("{54842BE9-0EE3-42D6-A57D-B9EACB65A535}", "@ConvertToDecimalAchievementName",
        AchievementDescription = "@ConvertToDecimalAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToDecimalAchievement : AbstractMethodCall
    {
        public ConvertToDecimalAchievement() : base("System.Convert.ToDecimal")
        {
        }
    }

    [AchievementDescriptor("{BCCA8025-AE5E-45D0-B2F1-43D09BD73999}", "@ConvertToDoubleAchievementName",
        AchievementDescription = "@ConvertToDoubleAchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToDoubleAchievement : AbstractMethodCall
    {
        public ConvertToDoubleAchievement() : base("System.Convert.ToDouble")
        {
        }
    }

    [AchievementDescriptor("{7FB029D2-2D67-4F02-8BF3-8C9278860F15}", "@ConvertToInt32AchievementName",
        AchievementDescription = "@ConvertToInt32AchievementDescription",
        AchievementCategory = "@Converting")]
    public class ConvertToInt32Achievement : AbstractMethodCall
    {
        public ConvertToInt32Achievement() : base("System.Convert.ToInt32")
        {
        }
    }
}
