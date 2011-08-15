using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Assign a char value", AchievementDescription = "Assign a value to an existing char variable", AchievementCategory = "Primitive type")]
    public class AssignChar : AssignValueToPrimitiveType<char>
    {
    }
}
