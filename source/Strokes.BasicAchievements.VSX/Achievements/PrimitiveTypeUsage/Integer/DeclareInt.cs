using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare an int", AchievementDescription = "Declare, but do not initialize, an int in one statement", AchievementCategory = "Basic Achievements")]
    public class DeclareInt : DeclarePrimitiveType<int>
    {
    }
}
