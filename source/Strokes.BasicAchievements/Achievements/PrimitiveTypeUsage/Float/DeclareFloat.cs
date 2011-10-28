using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{513392CD-ECDE-4F79-AA37-87BC6F8310E3}", "@DeclareFloatName",
        AchievementDescription = "@DeclareFloatDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareFloat : DeclarePrimitiveType<float>
    {
    }
}
