﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{3793453C-C67F-4241-B714-D1D0DC580BA1}", "@UpperBoundaryValueFloatName",
        AchievementDescription = "@UpperBoundaryValueFloatDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.single.maxvalue.aspx",
        AchievementCategory = "@PrimitiveType")]
    public class UpperBoundaryValueFloat : AssignUpperBoundaryValue<float>
    {
    }

    [AchievementDescriptor("{A23BC188-DBB1-4D36-B30A-DEF9FCED1ECF}", "@LowerBoundaryValueFloatName",
        AchievementDescription = "@LowerBoundaryValueFloatDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.single.minvalue.aspx",
        AchievementCategory = "@PrimitiveType")]
    public class LowerBoundaryValueFloat : AssignLowerBoundaryValue<float>
    {
    }
}
