using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize an int", AchievementDescription = "Declare and initialize an int in one statement", AchievementCategory = "Primitive type")]
    public class DeclareInitializeInt : DeclareInitializePrimitiveType<int>
    {
    }
}
