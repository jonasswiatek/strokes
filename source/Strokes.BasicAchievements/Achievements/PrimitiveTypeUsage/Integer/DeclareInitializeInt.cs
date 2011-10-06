using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareInitializeIntName",
        AchievementDescription = "@DeclareInitializeIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeInt : DeclareInitializePrimitiveType<int>
    {
    }
}
