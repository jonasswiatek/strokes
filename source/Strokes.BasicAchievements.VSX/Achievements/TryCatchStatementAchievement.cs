using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Try-Catch Statement", AchievementDescription = "Use a try-catch statement",
        AchievementCategory = "Basic Achievements")]
    public class TryCatchStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if (tryCatchStatement.CatchClauses.Count > 0 && tryCatchStatement.FinallyBlock.IsNull)
                {
                    IsAchievementUnlocked = true;
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}