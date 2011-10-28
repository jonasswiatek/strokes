using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A44096CE-18C2-4D5B-B3F7-467D6FDC3132}", "@DeclareIntName",
        AchievementDescription = "@DeclareIntDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInt : DeclarePrimitiveType<int>
    {
    }
}
