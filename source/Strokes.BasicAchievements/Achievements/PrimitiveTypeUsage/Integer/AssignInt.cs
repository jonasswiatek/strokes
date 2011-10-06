using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@AssignIntName",
        AchievementDescription = "@AssignIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignInt : AssignValueToPrimitiveType<int>
    {
    }
}
