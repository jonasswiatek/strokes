using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare multiple chars in one statement", AchievementDescription = "Declare multiple chars in one go", AchievementCategory = "Primitive type")]
    public class MultipleDeclareChar : MultipleDeclarePrimitiveType<char>
    {
    }
}
