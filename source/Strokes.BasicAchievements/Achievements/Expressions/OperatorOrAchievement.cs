using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{76E9BDF0-FBB6-48AB-868F-6DC068416BF2}", "@OperatorOrAchievementName",
        AchievementDescription = "@OperatorOrAchievementDescription",
        AchievementCategory = "@Expressions",
        Image="/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/OrOperator.png")]
    public class OperatorOrAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }



        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.LogicalOr)
                    UnlockWith(binaryOperatorExpression);

                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }
}