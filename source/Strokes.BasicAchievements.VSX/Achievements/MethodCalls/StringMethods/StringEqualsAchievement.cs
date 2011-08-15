using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("String equals", AchievementDescription = "Use the String.Equals method", AchievementCategory = "Strings")]
    public class StringEqualsAchievement : AbstractMethodCall
    {
        public StringEqualsAchievement() : base("System.String.Equals")
        {
        }
    }
}
