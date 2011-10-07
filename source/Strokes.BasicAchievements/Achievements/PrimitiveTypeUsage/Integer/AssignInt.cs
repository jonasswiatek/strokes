using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{D01B5C8C-04E8-47D6-81CE-66AA860E4367}", "@AssignIntName",
        AchievementDescription = "@AssignIntDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignInt : AssignValueToPrimitiveType<int>
    {
    }
}
