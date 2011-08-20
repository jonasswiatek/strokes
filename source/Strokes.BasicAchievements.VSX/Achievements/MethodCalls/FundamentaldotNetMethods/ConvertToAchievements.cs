using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Convert to Char", AchievementDescription = "Use the Convert.ToChar method", AchievementCategory = "Converting")]
    public class ConvertToCharAchievement : AbstractMethodCall
    {
        public ConvertToCharAchievement() : base("System.Convert.ToChar")
        {
        }
    }

    [AchievementDescription("Convert to Decimal", AchievementDescription = "Use the Convert.ToDecimal method", AchievementCategory = "Converting")]
    public class ConvertToDecimalAchievement : AbstractMethodCall
    {
        public ConvertToDecimalAchievement()
            : base("System.Convert.ToDecimal")
        {
        }
    }

    [AchievementDescription("Convert to double", AchievementDescription = "Use the Convert.ToDouble method", AchievementCategory = "Converting")]
    public class ConvertToDoubleAchievement : AbstractMethodCall
    {
        public ConvertToDoubleAchievement()
            : base("System.Convert.ToDouble")
        {
        }
    }

    [AchievementDescription("Convert to Int32", AchievementDescription = "Use the Convert.ToInt32 method", AchievementCategory = "Converting")]
    public class ConvertToInt32Achievement : AbstractMethodCall
    {
        public ConvertToInt32Achievement()
            : base("System.Convert.ToInt32")
        {
        }
    }
}
