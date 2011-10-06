using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@UpperBoundaryValueFloatName",
        AchievementDescription = "@UpperBoundaryValueFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueFloat : AssignUpperBoundaryValue<float>
    {
    }

    [AchievementDescription("@LowerBoundaryValueFloatName",
        AchievementDescription = "@LowerBoundaryValueFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueFloat : AssignLowerBoundaryValue<float>
    {
    }
}
