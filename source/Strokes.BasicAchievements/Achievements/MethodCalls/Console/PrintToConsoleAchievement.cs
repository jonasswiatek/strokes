    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{EED2F567-0305-4543-8A36-847A5D4176A9}", "@PrintToConsoleAchievementName",
        AchievementDescription = "@PrintToConsoleAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.console.writeline(v=VS.110).aspx",
        AchievementCategory = "@Console")]
    public class PrintToConsoleAchievement : AbstractSystemTypeUsage
    {
        public PrintToConsoleAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }
    }
}