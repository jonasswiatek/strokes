using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Try-Finally Statement",
        AchievementDescription = "Use the a try-finally without a catch statement.",
        AchievementCategory = "Basic Achievements")]
    public class TryFinallyStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if (tryCatchStatement.CatchClauses.Count == 0 && !tryCatchStatement.FinallyBlock.IsNull)
                {
                    UnlockWith(tryCatchStatement);
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}