using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{09FA8C6F-26DC-4361-8AFD-EB979BEB50D8}", "@TryCatchIgnoreStatementAchievementName",
        AchievementDescription = "@TryCatchIgnoreStatementAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class TryCatchIgnoreStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                var defaultCatchClause = tryCatchStatement.CatchClauses.FirstOrDefault(a => a.Type.IsNull);
                if(defaultCatchClause != null)
                {
                    UnlockWith(defaultCatchClause);
                }

                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}