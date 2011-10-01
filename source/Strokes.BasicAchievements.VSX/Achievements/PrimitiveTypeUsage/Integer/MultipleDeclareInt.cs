using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@MultipleDeclareIntName",
        AchievementDescription = "@MultipleDeclareIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareInt : MultipleDeclarePrimitiveType<int>
    {
    }
}
