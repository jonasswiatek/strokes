﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{349D23BD-D117-4095-9A2E-381090EC2A51}", "@ConvertToCharAchievementName",
        AchievementDescription = "@ConvertToCharAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.convert(v=VS.110).aspx",
        AchievementCategory = "@Converting")]
    public class ConvertToCharAchievement : AbstractSystemTypeUsage
    {
        public ConvertToCharAchievement() : base(typeof(System.Convert), "ToChar")
        {
        }
    }

    [AchievementDescriptor("{54842BE9-0EE3-42D6-A57D-B9EACB65A535}", "@ConvertToDecimalAchievementName",
        AchievementDescription = "@ConvertToDecimalAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.convert(v=VS.110).aspx",
        AchievementCategory = "@Converting")]
    public class ConvertToDecimalAchievement : AbstractSystemTypeUsage
    {
        public ConvertToDecimalAchievement() : base(typeof(System.Convert), "ToDecimal")
        {
        }
    }

    [AchievementDescriptor("{BCCA8025-AE5E-45D0-B2F1-43D09BD73999}", "@ConvertToDoubleAchievementName",
        AchievementDescription = "@ConvertToDoubleAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.convert(v=VS.110).aspx",
        AchievementCategory = "@Converting")]
    public class ConvertToDoubleAchievement : AbstractSystemTypeUsage
    {
        public ConvertToDoubleAchievement() : base(typeof(System.Convert), "ToDouble")
        {
        }
    }

    [AchievementDescriptor("{7FB029D2-2D67-4F02-8BF3-8C9278860F15}", "@ConvertToInt32AchievementName",
        AchievementDescription = "@ConvertToInt32AchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.convert(v=VS.110).aspx",
        AchievementCategory = "@Converting")]
    public class ConvertToInt32Achievement : AbstractSystemTypeUsage
    {
        public ConvertToInt32Achievement() : base(typeof(System.Convert), "ToInt32")
        {
        }
    }
}
