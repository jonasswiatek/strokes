using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A777AB0D-130B-44F0-86DE-40AB509F01CA}", "@IfCompoundExpressionAchievementName",
        AchievementDescription = "@IfCompoundExpressionAchievementDescription",
        AchievementCategory = "@Expressions",
        DependsOn = new[]
        {
            "{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}"
        })]
    public class IfCompoundExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                // TODO: Verify the IfCompoundExpression Achievement.
                var condition = ifElseStatement.Condition as BinaryOperatorExpression;
                if (condition != null && condition.Operator != BinaryOperatorType.Equality) 
                    UnlockWith(ifElseStatement);

                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}