using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B9AEEF5B-C062-4580-B9D9-842D6A53EBE7}", "@DefaultCaseInSwitchSwitchAchievementName",
        AchievementDescription = "@DefaultCaseInSwitchSwitchAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DefaultCaseInSwitchSwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitSwitchSection(SwitchSection switchSection, object data)
            {
                if(switchSection.CaseLabels.Any(a => a.Expression.IsNull))
                {
                    UnlockWith(switchSection);
                }

                return base.VisitSwitchSection(switchSection, data);
            }

        }
    }
}