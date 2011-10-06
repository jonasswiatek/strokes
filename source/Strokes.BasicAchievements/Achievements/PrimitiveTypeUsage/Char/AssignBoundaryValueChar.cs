using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@UpperBoundaryValueCharName",
        AchievementDescription = "@UpperBoundaryValueCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueChar : AssignUpperBoundaryValue<char>
    {
    }

    [AchievementDescription("@LowerBoundaryValueCharName",
        AchievementDescription = "@LowerBoundaryValueCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueChar : AssignLowerBoundaryValue<char>
    {
    }
}
