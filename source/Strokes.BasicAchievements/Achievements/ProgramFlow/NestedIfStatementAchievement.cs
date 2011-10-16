using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A050D53A-F434-48EB-8A22-3F44F6D5F1DF}", "@NestedIfStatementAchievementName",
        AchievementDescription = "@NestedIfStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class NestedIfStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                foreach (var statement in (ifElseStatement.TrueStatement as BlockStatement).Statements)
                {
                    if (statement is IfElseStatement)
                        UnlockWith(ifElseStatement);
                }

                foreach (var statement in (ifElseStatement.FalseStatement as BlockStatement).Statements)
                {
                    if (statement is IfElseStatement)
                        UnlockWith(ifElseStatement);
                }

                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}