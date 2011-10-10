using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{E206C7DC-71C5-416A-B14A-B5196BBBD4D0}", "@AssignCharName",
        AchievementDescription = "@AssignCharDescription",
        AchievementCategory = "@PrimitiveType")]
    public class AssignChar : AssignValueToPrimitiveType<char>
    {
    }
}
