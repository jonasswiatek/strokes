using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize float", AchievementDescription = "Declare and initialize a float in one statement", AchievementCategory = "Primitive type")]
    public class DeclareInitializeFloat : DeclareInitializePrimitiveType<float>
    {
    }
}
