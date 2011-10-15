using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{6EF57815-35C1-415B-B503-4EF2105F8AEC}", "@OperatorAndAchievementName",
        AchievementDescription = "@OperatorAndAchievementDescription",
        AchievementCategory = "@Expressions",
        Image = "/Strokes.BasicAchievements;component/Achievements/Icons/Basic/AndOperator.png",
        DependsOn = new[]
        {
            "{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}"
        })]
    public class OperatorAndAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
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