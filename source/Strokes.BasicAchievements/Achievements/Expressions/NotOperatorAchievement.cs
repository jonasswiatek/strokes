using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A4A094CB-57AC-41FF-8562-29A5ACCC9076}", "@NotOperatorAchievementName",
        AchievementDescription = "@NotOperatorAchievementDescription",
        Image = "/Strokes.BasicAchievements;component/Achievements/Icons/Basic/NotOperator.png",
        AchievementCategory = "@Expressions",
        DependsOn = new[]
        {
            "{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}"
        })]
    public class NotOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                var expression = ifElseStatement.Condition as UnaryOperatorExpression;
                if (expression != null && expression.Operator == UnaryOperatorType.Not)
                    UnlockWith(ifElseStatement);

                return base.VisitIfElseStatement(ifElseStatement, data);
            }

        }
    }
}