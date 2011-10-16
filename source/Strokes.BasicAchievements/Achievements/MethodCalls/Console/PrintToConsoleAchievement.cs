using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{EED2F567-0305-4543-8A36-847A5D4176A9}", "@PrintToConsoleAchievementName",
        AchievementDescription = "@PrintToConsoleAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintToConsoleAchievement : AbstractMethodCall
    {
        public PrintToConsoleAchievement()
            : base("Console.WriteLine")
        {
        }
    }
}
