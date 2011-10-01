using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareInitializeCharName",
        AchievementDescription = "@DeclareInitializeCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeChar : DeclareInitializePrimitiveType<char>
    {
    }
}
