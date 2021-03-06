﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{FF959777-82A7-4BDC-BFCE-088586A06723}", "@UseConsoleReadlineAchievementName",
        AchievementDescription = "@UseConsoleReadlineAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.console.readline.aspx",
        AchievementCategory = "@Console")]
    public class UseConsoleReadlineAchievement : AbstractSystemTypeUsage
    {
        public UseConsoleReadlineAchievement() : base(typeof(System.Console), "ReadLine")
        {
        }
    }
}
