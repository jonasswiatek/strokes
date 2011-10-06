using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@AssignDoubleName",
        AchievementDescription = "@AssignDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignDouble : AssignValueToPrimitiveType<double>
    {
    }
}
