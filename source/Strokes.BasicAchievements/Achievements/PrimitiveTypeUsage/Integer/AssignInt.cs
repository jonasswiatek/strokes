using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{D01B5C8C-04E8-47D6-81CE-66AA860E4367}", "@AssignIntName",
        AchievementDescription = "@AssignIntDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class AssignInt : AssignValueToPrimitiveType<int>
    {
    }
}
