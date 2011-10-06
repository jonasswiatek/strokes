using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@UpperBoundaryValueFDoubleName",
        AchievementDescription = "@UpperBoundaryValueFDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueFDouble : AssignUpperBoundaryValue<double>
    {
    }

    [AchievementDescription("@LowerBoundaryValuedoubleName",
        AchievementDescription = "@LowerBoundaryValuedoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValuedouble : AssignLowerBoundaryValue<double>
    {
    }
}
