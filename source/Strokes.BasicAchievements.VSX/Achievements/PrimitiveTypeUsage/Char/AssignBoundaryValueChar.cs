using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Living on the char edge", AchievementDescription = "Assign the maximal allowed value to a char (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class UpperBoundaryValueChar : AssignUpperBoundaryValue<char>
    {
    }

    [AchievementDescription("Living on the negative double edge", AchievementDescription = "Assign the minimal allowed value to a char (beware the overflow!)", AchievementCategory = "Primitive type")]
    public class LowerBoundaryValueChar : AssignLowerBoundaryValue<char>
    {
    }
}
