using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@LambdaExpressionAchievementName",
        AchievementDescription = "@LambdaExpressionAchievementDescription",
        AchievementCategory = "@Expressions",
        Image = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/LambdaExpr.png")]
    public class LambdaExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLambdaExpression(LambdaExpression lambdaExpression, object data)
            {
                UnlockWith(lambdaExpression);
                return base.VisitLambdaExpression(lambdaExpression, data);
            }
        }
    }
}