using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{DAF1BF14-32CB-43C8-9163-521EBE2C23DD}", "@ElseIfStatementAchievementName",
        AchievementDescription = "@ElseIfStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class ElseIfStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                if (ifElseStatement.FalseStatement is IfElseStatement)
                    UnlockWith(ifElseStatement.ElseToken);

                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}