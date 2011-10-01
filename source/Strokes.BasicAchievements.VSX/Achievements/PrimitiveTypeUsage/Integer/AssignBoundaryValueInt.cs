using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@UpperBoundaryValueIntName",
        AchievementDescription = "@UpperBoundaryValueIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueInt : AssignUpperBoundaryValue<int>
    {
    }

    [AchievementDescription("@LowerBoundaryValueIntName",
        AchievementDescription = "@LowerBoundaryValueIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueInt : AssignLowerBoundaryValue<int>
    {
    }
}
