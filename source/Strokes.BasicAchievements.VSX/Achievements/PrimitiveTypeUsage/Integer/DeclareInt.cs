using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareIntName",
        AchievementDescription = "@DeclareIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInt : DeclarePrimitiveType<int>
    {
    }
}
