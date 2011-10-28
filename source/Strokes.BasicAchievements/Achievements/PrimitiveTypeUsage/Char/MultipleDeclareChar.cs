using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{EB0578CA-DBF7-4EC0-85E1-F111DFB9A4F1}", "@MultipleDeclareCharName",
        AchievementDescription = "@MultipleDeclareCharDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareChar : MultipleDeclarePrimitiveType<char>
    {
    }
}
