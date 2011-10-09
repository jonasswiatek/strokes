using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0B4EF775-FDE2-4EAB-B97B-E217DF9A300F}", "@UpperBoundaryValueIntName",
        AchievementDescription = "@UpperBoundaryValueIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueInt : AssignUpperBoundaryValue<int>
    {
    }

    [AchievementDescriptor("{68DCCD1F-15D5-4917-B27B-321609EF62BF}", "@LowerBoundaryValueIntName",
        AchievementDescription = "@LowerBoundaryValueIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueInt : AssignLowerBoundaryValue<int>
    {
    }
}
