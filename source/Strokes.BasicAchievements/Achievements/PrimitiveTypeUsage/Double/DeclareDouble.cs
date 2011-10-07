using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{6A7F44EB-F96E-4702-9406-286853C08A37}", "@MultipleDeclareDoubleName",
        AchievementDescription = "@MultipleDeclareDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareDouble : DeclarePrimitiveType<double>
    {
    }
}
