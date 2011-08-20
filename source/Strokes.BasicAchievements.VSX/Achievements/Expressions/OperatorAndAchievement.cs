using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Use AND (&&) operator", AchievementDescription = "Make use of the AND operator", AchievementCategory = "Expressions",
    Image = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/AndOperator.png")]
    public class OperatorAndAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.LogicalAnd)
                    UnlockWith(binaryOperatorExpression);

                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }
}