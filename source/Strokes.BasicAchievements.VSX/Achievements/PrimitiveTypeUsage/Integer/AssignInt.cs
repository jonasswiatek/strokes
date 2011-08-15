using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Assign an integer value", AchievementDescription = "Assign a value to an existing integer variable", AchievementCategory = "Primitive type")]
    public class AssignInt : AssignValueToPrimitiveType<int>
    {
    }
}
