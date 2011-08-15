using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Assign a float value", AchievementDescription = "Assign a value to an existing float variable", AchievementCategory = "Primitive type")]
    public class AssignFloat : AssignValueToPrimitiveType<float>
    {
    }
}
