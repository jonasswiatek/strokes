using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare a float", AchievementDescription = "Declare, but do not initialize, a float in one statement", AchievementCategory = "Basic Achievements")]
    public class DeclareFloat : DeclarePrimitiveType<float>
    {
    }
}
