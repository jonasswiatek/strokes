using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5CD28A90-176A-4955-94A2-0B5AD9DB672F}", "@MultipleDeclareIntName",
        AchievementDescription = "@MultipleDeclareIntDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareInt : MultipleDeclarePrimitiveType<int>
    {
    }
}
