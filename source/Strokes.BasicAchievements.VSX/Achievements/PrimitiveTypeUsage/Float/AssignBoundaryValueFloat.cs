using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Living on the floating edge", AchievementDescription = "Assign the maximal allowed value to a float (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class UpperBoundaryValueFloat : AssignUpperBoundaryValue<float>
    {
    }

    [AchievementDescription("Living on the negative floating edge", AchievementDescription = "Assign the minimal allowed value to a float (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class LowerBoundaryValueFloat : AssignLowerBoundaryValue<float>
    {
    }
}
