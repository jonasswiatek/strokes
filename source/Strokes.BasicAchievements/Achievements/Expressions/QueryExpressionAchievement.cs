using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5DFEED98-ED56-433C-8E06-D71AC7ED2E1E}", "@QueryExpressionAchievementName",
        AchievementDescription = "@QueryExpressionAchievementDescription",
        AchievementCategory = "@Expressions")]
    public class QueryExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
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