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
                foreach (var label in switchSection.SwitchLabels)
                {
                    if (label.IsDefault)
                        IsAchievementUnlocked = true;
                }
                return base.VisitSwitchSection(switchSection, data);
            }
        }
    }
}