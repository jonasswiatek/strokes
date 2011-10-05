using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@UseConsoleReadlineAchievementName",
        AchievementDescription = "@UseConsoleReadlineAchievementDescription",
        AchievementCategory = "@Console")]
    public class UseConsoleReadlineAchievement : AbstractMethodCall
    {
        public UseConsoleReadlineAchievement() : base("Console.ReadLine")
        {
        }
    }
}
