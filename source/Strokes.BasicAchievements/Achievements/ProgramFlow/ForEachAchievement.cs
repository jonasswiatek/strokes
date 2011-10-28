using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{F328611E-562D-4D8B-B1AE-48830DB00C7E}", "@ForEachAchievementName",
        AchievementDescription = "@ForEachAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ttw7t8t6.aspx",
        AchievementCategory = "@ProgramFlow")]
    public class ForEachAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitForeachStatement(ForeachStatement foreachStatement, object data)
            {
                UnlockWith(foreachStatement);

                return base.VisitForeachStatement(foreachStatement, data);
            }
        }
    }
}