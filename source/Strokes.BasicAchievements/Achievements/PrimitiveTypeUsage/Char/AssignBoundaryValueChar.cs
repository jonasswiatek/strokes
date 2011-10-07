using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{585FA5E2-2218-4E31-8AF8-DBAF6E3A3943}", "@UpperBoundaryValueCharName",
        AchievementDescription = "@UpperBoundaryValueCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueChar : AssignUpperBoundaryValue<char>
    {
    }

    [AchievementDescription("{93CF3F6D-EB76-4872-B26E-ED5855E865E9}", "@LowerBoundaryValueCharName",
        AchievementDescription = "@LowerBoundaryValueCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueChar : AssignLowerBoundaryValue<char>
    {
    }
}
