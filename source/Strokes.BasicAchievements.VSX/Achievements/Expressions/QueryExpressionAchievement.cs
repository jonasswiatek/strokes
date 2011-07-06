using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Query Expression", AchievementDescription = "Use a query expression",
        AchievementCategory = "Basic Achievements")]
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
                IsAchievementUnlocked = true;
                return base.VisitQueryExpression(queryExpression, data);
            }
        }
    }
}