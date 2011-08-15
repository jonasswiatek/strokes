using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Ghost in the Shell", AchievementDescription = "Print something to the console", AchievementCategory = "Console")]
    public class PrintToConsoleAchievement : AbstractMethodCall
    {
        public PrintToConsoleAchievement() : base("System.Console.WriteLine")
        {
        }
    }
}
