using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{319C800D-EA11-4381-BD61-3F9B1A246C6F}", "@TryCatchRethrowStatementAchievementName",
        AchievementDescription = "@TryCatchRethrowStatementAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class TryCatchRethrowStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
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
                        var throwStatement = catchClause.Body.Statements.FirstOrDefault(a => a is ThrowStatement);
                        if(throwStatement != null)
                        {
                            UnlockWith(throwStatement);
                        }
                    }
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}