using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{7F3F1B9E-D2B3-42D3-9686-3C3BD51D8192}", "@TryCatchFinallyStatementAchievementName",
        AchievementDescription = "@TryCatchFinallyStatementAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class TryCatchFinallyStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if(tryCatchStatement.CatchClauses.Count > 0 && !tryCatchStatement.FinallyBlock.IsNull)
                {
                    UnlockWith(tryCatchStatement);
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}