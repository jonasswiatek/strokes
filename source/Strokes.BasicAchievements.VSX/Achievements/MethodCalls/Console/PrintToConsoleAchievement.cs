using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@PrintToConsoleAchievementName",
        AchievementDescription = "@PrintToConsoleAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintToConsoleAchievement : AbstractMethodCall
    {
        public PrintToConsoleAchievement() : base("System.Console.WriteLine")
        {
        }
    }
}
