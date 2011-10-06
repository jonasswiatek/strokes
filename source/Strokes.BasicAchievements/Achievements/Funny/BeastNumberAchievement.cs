using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@BeastNumberAchievementName",
        AchievementDescription = "@BeastNumberAchievementDescription",
        AchievementCategory = "@Funny")]
    public class BeastNumberAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                if(assignmentExpression.Right is PrimitiveExpression)
                {
                    PrimitiveExpression prim = (PrimitiveExpression) assignmentExpression.Right;

                    int number;
                    if (int.TryParse(prim.StringValue, out number))
                    {
                        if (number == 666)
                            UnlockWith(assignmentExpression);
                    }
                }
                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}