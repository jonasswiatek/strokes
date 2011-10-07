using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{513392CD-ECDE-4F79-AA37-87BC6F8310E3}", "@MultipleDeclareFloatName",
        AchievementDescription = "@MultipleDeclareFloatDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareFloat : DeclarePrimitiveType<float>
    {
    }
}
