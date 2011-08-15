using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare a double", AchievementDescription = "Declare, but do not initialize, a double in one statement", AchievementCategory = "Primitive type")]
    public class DeclareDouble : DeclarePrimitiveType<double>
    {
    }
}
