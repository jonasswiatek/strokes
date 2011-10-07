using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{DF7B3DD0-6133-430B-B730-F55BFF493115}", "@DeclareInitializeCharName",
        AchievementDescription = "@DeclareInitializeCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareInitializeChar : DeclareInitializePrimitiveType<char>
    {
    }
}
