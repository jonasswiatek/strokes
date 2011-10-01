using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@AssignCharName",
        AchievementDescription = "@AssignCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignChar : AssignValueToPrimitiveType<char>
    {
    }
}
