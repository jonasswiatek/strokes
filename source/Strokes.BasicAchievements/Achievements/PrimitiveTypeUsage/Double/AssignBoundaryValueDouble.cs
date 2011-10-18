using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{DFF44799-2F55-4E89-8B44-40D15544F5D0}", "@UpperBoundaryValueFDoubleName",
        AchievementDescription = "@UpperBoundaryValueFDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueDouble : AssignUpperBoundaryValue<double>
    {
    }

    [AchievementDescriptor("{969E200D-5754-490B-A2AF-165F0EBCBE12}", "@LowerBoundaryValuedoubleName",
        AchievementDescription = "@LowerBoundaryValuedoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueDouble : AssignLowerBoundaryValue<double>
    {
    }
}
