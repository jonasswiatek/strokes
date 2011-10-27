using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B012CA29-340C-47D0-8D39-E2F83FB59D1A}", "@DeclareArrayAchievementName",
        AchievementDescription = "@DeclareArrayAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/0a7fscd0.aspx",
        AchievementCategory = "@Arrays")]
    public class DeclareArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
            {
                UnlockWith(arraySpecifier);
                return base.VisitArraySpecifier(arraySpecifier, data);
            }
        }
    }
}