using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Invert!", AchievementDescription = "Use a not operator to invert an expression", AchievementCategory = "Basic Achievements"
        ,Image = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/NotOperator.png")]
    public class NotOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                UnaryOperatorExpression expr= ifElseStatement.Condition as UnaryOperatorExpression;
                if (expr != null)
                {
                    if (expr.Op == UnaryOperatorType.Not)
                        UnlockWith(ifElseStatement);
                }
                return base.VisitIfElseStatement(ifElseStatement, data);
            }
            
        }
    }
}