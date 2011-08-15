using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare a char", AchievementDescription = "Declare, but do not initialize, a char in one statement", AchievementCategory = "Primitive type")]
    public class DeclareChar : DeclarePrimitiveType<char>
    {
    }
}
