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
}
