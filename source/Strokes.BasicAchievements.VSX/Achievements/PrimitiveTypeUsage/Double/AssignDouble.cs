using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Assign a double value", AchievementDescription = "Assign a value to an existing double variable", AchievementCategory = "Primitive type")]
    public class AssignDouble : AssignValueToPrimitiveType<double>
    {
    }
}
