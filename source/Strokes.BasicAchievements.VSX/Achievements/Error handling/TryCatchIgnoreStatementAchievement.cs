using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Try-Catch-Ignore", AchievementDescription = "Write an empty catch statement",
        AchievementCategory = "Error handling")]
    public class TryCatchIgnoreStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if (tryCatchStatement.CatchClauses.Count > 0)
                {
                    foreach (CatchClause catchClause in tryCatchStatement.CatchClauses)
                    {
                        if (catchClause.StatementBlock.Children.Count == 0) 
                            UnlockWith(tryCatchStatement);
                    }
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}