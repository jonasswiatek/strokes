using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{C8FD8F22-33E7-4968-B66F-D04EBF0BAE82}", "@AssignFloatName",
        AchievementDescription = "@AssignFloatDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms228360(v=vs.80).aspx",
        AchievementCategory = "@PrimitiveType")]
    public class AssignFloat : AssignValueToPrimitiveType<float>
    {
    }
}
