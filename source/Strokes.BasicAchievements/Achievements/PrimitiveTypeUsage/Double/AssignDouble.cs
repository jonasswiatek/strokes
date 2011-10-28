using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{30E4AA3F-6170-4589-88B3-7DF03CD7AC11}", "@AssignDoubleName",
        AchievementDescription = "@AssignDoubleDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class AssignDouble : AssignValueToPrimitiveType<double>
    {
    }
}
