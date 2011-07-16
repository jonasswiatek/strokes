using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Define a default switch case", AchievementDescription = "Create a default case in a  switch statement", AchievementCategory = "Basic Achievements")]
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