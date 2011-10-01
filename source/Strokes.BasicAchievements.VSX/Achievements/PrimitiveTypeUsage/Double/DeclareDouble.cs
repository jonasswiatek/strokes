using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@MultipleDeclareDoubleName",
        AchievementDescription = "@MultipleDeclareDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareDouble : DeclarePrimitiveType<double>
    {
    }
}
