using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{FF959777-82A7-4BDC-BFCE-088586A06723}", "@UseConsoleReadlineAchievementName",
        AchievementDescription = "@UseConsoleReadlineAchievementDescription",
        AchievementCategory = "@Console")]
    public class UseConsoleReadlineAchievement : AbstractMethodCall
    {
        public UseConsoleReadlineAchievement() : base("Console.ReadLine")
        {
        }
    }
}
