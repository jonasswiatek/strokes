using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare multiple doubles in one statement", AchievementDescription = "Declare multiple doubles in one go", AchievementCategory = "Primitive type")]
    public class MultipleDeclareDouble : MultipleDeclarePrimitiveType<double>
    {
    }
}
