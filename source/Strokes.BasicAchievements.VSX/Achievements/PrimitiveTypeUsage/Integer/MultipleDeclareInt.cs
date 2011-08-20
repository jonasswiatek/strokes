using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare multiple integers in one statement", AchievementDescription = "Declare multiple integers in one go", AchievementCategory = "Primitive type")]
    public class MultipleDeclareInt : MultipleDeclarePrimitiveType<int>
    {
    }
}
