using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{53FAAC04-576E-4029-8138-E645D3B704C8}", "@LambdaExpressionAchievementName",
        AchievementDescription = "@LambdaExpressionAchievementDescription",
        AchievementCategory = "@Expressions",
        Image = "/Strokes.BasicAchievements;component/Achievements/Icons/Basic/LambdaExpr.png")]
    public class LambdaExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
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