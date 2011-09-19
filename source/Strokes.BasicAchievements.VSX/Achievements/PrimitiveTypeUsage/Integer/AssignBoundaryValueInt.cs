using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Living on the edge", AchievementDescription = "Assign the maximal allowed value to an integer (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class UpperBoundaryValueInt : AssignUpperBoundaryValue<int>
    {
    }

    [AchievementDescription("Living on the negative edge", AchievementDescription = "Assign the minimal allowed value to an integer (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class LowerBoundaryValueInt : AssignLowerBoundaryValue<int>
    {
    }
}
