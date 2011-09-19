using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Living on the double edge", AchievementDescription = "Assign the maximal allowed value to a double (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class UpperBoundaryValueFDouble : AssignUpperBoundaryValue<double>
    {
    }

    [AchievementDescription("Living on the negative double edge", AchievementDescription = "Assign the minimal allowed value to a double (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class LowerBoundaryValuedouble : AssignLowerBoundaryValue<double>
    {
    }
}
