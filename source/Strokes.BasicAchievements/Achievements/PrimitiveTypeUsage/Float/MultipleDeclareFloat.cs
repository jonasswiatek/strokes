using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{E77EF437-8C58-4A31-A09B-86EDB2A476F0}", "@MultipleDeclareFloatName",
        AchievementDescription = "@MultipleDeclareFloatDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareFloat : MultipleDeclarePrimitiveType<float>
    {
    }
}
