using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{A44096CE-18C2-4D5B-B3F7-467D6FDC3132}", "@DeclareIntName",
        AchievementDescription = "@DeclareIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInt : DeclarePrimitiveType<int>
    {
    }
}
