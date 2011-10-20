using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{FDCBFA55-8DE1-4E35-B924-AA9DB88AEF4D}", "@UseIsKeywordAchievementName",
        AchievementDescription = "@UseIsKeywordAchievementDescription",
        AchievementCategory = "@Class")]
    public class UseIsKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIsExpression(ICSharpCode.NRefactory.CSharp.IsExpression isExpression, object data)
            {
                UnlockWith(isExpression);
                return base.VisitIsExpression(isExpression, data);
            }
        }
    }
}