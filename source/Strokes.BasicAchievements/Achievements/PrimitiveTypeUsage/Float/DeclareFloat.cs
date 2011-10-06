using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@MultipleDeclareFloatName",
        AchievementDescription = "@MultipleDeclareFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareFloat : DeclarePrimitiveType<float>
    {
    }
}
