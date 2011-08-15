using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Use Console.ReadLine()", AchievementDescription = "Get input from the user", AchievementCategory = "Console")]
    public class UseConsoleReadlineAchievement : AbstractMethodCall
    {
        public UseConsoleReadlineAchievement() : base("System.Console.ReadLine")
        {
        }
    }
}
