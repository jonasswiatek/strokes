using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A7B577B2-6ACE-4A43-94FF-33483053FCF2}", "@UseAsKeywordAchievementName",
        AchievementDescription = "@UseAsKeywordAchievementDescription",
        AchievementCategory = "@Class")]
    public class UseAsKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitAsExpression(AsExpression asExpression, object data)
            {
                UnlockWith(asExpression);
                return base.VisitAsExpression(asExpression, data);
            }
        }
    }
}