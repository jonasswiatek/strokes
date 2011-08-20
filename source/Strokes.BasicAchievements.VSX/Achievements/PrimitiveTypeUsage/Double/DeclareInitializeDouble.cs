using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize a double", AchievementDescription = "Declare and initialize a double in one statement", AchievementCategory = "Primitive type")]
    public class DeclareInitializeDouble : DeclareInitializePrimitiveType<double>
    {
    }
}
