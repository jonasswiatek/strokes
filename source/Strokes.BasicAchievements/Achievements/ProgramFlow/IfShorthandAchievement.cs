using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@IfShorthandAchievementName",
        AchievementDescription = "@IfShorthandAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class IfShorthandAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitConditionalExpression(ConditionalExpression conditionalExpression, object data)
            {
                UnlockWith(conditionalExpression);
                return base.VisitConditionalExpression(conditionalExpression, data);
            }
        }
    }
}