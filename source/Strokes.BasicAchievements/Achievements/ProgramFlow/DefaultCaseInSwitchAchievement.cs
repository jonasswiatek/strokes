using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{B9AEEF5B-C062-4580-B9D9-842D6A53EBE7}", "@DefaultCaseInSwitchSwitchAchievementName",
        AchievementDescription = "@DefaultCaseInSwitchSwitchAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DefaultCaseInSwitchSwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitSwitchSection(SwitchSection switchSection, object data)
            {
                //Slightly improved, so only the actual default label will highlight, and not the entire switch statement.
                var defaultLabel = switchSection.SwitchLabels.FirstOrDefault(a => a.IsDefault);
                if(defaultLabel != null)
                    UnlockWith(defaultLabel);

                return base.VisitSwitchSection(switchSection, data);
            }
        }
    }
}