using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{A763698C-DE1D-455E-A44A-78407B97A0BF}", "@DeclareInitializeDoubleName",
        AchievementDescription = "@DeclareInitializeDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeDouble : DeclareInitializePrimitiveType<double>
    {
    }
}
