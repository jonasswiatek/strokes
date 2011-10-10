using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{21920D75-FDD5-4F60-AC84-5AA227FA4FD4}", "@MultipleDeclareCharName",
        AchievementDescription = "@MultipleDeclareCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareChar : DeclarePrimitiveType<char>
    {
    }
}
