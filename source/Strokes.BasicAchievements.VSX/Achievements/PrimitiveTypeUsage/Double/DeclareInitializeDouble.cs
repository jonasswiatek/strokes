using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareInitializeDoubleName",
        AchievementDescription = "@DeclareInitializeDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeDouble : DeclareInitializePrimitiveType<double>
    {
    }
}
