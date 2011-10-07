using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{A050D53A-F434-48EB-8A22-3F44F6D5F1DF}", "@NestedIfStatementAchievementName",
        AchievementDescription = "@NestedIfStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class NestedIfStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                foreach (Statement statement in ifElseStatement.TrueStatement)
                {
                    if (statement is IfElseStatement)
                        UnlockWith(ifElseStatement);
                }
                foreach (Statement statement in ifElseStatement.FalseStatement)
                {
                    if (statement is IfElseStatement)
                        UnlockWith(ifElseStatement);
                }
                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}