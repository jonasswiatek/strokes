﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{3286DCDD-973F-41B3-9557-ABB390953AD1}", "@MultipleDeclareDoubleName",
        AchievementDescription = "@MultipleDeclareDoubleDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareDouble : MultipleDeclarePrimitiveType<double>
    {
    }
}
