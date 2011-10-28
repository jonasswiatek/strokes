using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B4FDFDE4-C955-4667-8FA6-6E7E368C3CA5}", "@ForAchievementName",
        AchievementDescription = "@ForAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ch45axte.aspx",
        AchievementCategory = "@ProgramFlow")]
    public class ForAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitForStatement(ForStatement forStatement, object data)
            {
                UnlockWith(forStatement);

                return base.VisitForStatement(forStatement, data);
            }
        }
    }
}