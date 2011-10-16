using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{76E9BDF0-FBB6-48AB-868F-6DC068416BF2}", "@OperatorOrAchievementName",
        AchievementDescription = "@OperatorOrAchievementDescription",
        AchievementCategory = "@Expressions",
        Image="/Strokes.BasicAchievements;component/Achievements/Icons/Basic/OrOperator.png",
        DependsOn = new[]
        {
            "{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}"
        })]
    public class OperatorOrAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }



        private class Visitor : AbstractAchievementVisitor
        {
            /* //REFACTOR
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.LogicalOr)
                    UnlockWith(binaryOperatorExpression);

                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
             */
        }
    }
}