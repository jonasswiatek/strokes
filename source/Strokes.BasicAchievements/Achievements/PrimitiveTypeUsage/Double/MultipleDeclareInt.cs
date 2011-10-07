using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{3286DCDD-973F-41B3-9557-ABB390953AD1}", "@MultipleDeclareDoubleName",
        AchievementDescription = "@MultipleDeclareDoubleDescription",
        AchievementCategory = "@PrimitiveType")]
    public class MultipleDeclareDouble : MultipleDeclarePrimitiveType<double>
    {
    }
}
