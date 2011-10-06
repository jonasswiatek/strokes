using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@QueryExpressionAchievementName",
        AchievementDescription = "@QueryExpressionAchievementDescription",
        AchievementCategory = "@Expressions")]
    public class QueryExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitQueryExpression(QueryExpression queryExpression, object data)
            {
                UnlockWith(queryExpression);

                return base.VisitQueryExpression(queryExpression, data);
            }
        }
    }
}