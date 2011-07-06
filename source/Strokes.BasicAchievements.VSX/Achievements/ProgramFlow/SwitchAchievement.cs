using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Multiplexing", AchievementDescription = "Create a switch statement", AchievementCategory = "Basic Achievements")]
    public class SwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                IsAchievementUnlocked = true;
                return base.VisitSwitchStatement(switchStatement, data);
            }
        }
    }
}