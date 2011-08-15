using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize a char", AchievementDescription = "Declare and initialize a char in one statement", AchievementCategory = "Primitive type")]
    public class DeclareInitializeChar : DeclareInitializePrimitiveType<char>
    {
    }
}
