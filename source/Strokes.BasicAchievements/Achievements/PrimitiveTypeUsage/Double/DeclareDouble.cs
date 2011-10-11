using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{6A7F44EB-F96E-4702-9406-286853C08A37}", "@DeclareDoubleName",
        AchievementDescription = "@DeclareDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareDouble : DeclarePrimitiveType<double>
    {
    }
}
