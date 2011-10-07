using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{5BDC57E5-6D49-46C6-9E0F-7864CDB6BDF4}", "@DeclareInitializeFloatName",
        AchievementDescription = "@DeclareInitializeFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeFloat : DeclareInitializePrimitiveType<float>
    {
    }
}
