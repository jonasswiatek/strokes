using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{9E33F0A9-BEEC-4EA5-AD20-CFB14F970A46}", "@GotoAchievementName",
        AchievementDescription = "@GotoAchievementDescription",
        AchievementCategory = "@Funny")]
    public class GotoAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitGotoStatement(GotoStatement gotoStatement, object data)
            {
                UnlockWith(gotoStatement);

                return base.VisitGotoStatement(gotoStatement, data);
            }
        }
    }
}