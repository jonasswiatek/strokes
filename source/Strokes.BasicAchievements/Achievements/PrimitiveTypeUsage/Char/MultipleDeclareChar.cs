using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{EB0578CA-DBF7-4EC0-85E1-F111DFB9A4F1}", "@MultipleDeclareCharName",
        AchievementDescription = "@MultipleDeclareCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareChar : MultipleDeclarePrimitiveType<char>
    {
    }
}
