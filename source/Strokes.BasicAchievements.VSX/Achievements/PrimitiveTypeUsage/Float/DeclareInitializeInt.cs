using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareInitializeFloatName",
        AchievementDescription = "@DeclareInitializeFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeFloat : DeclareInitializePrimitiveType<float>
    {
    }
}
