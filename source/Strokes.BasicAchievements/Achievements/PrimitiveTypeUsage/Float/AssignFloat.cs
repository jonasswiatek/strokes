using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@AssignFloatName",
        AchievementDescription = "@AssignFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignFloat : AssignValueToPrimitiveType<float>
    {
    }
}
