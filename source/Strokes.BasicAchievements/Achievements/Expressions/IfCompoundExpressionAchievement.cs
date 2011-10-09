using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A777AB0D-130B-44F0-86DE-40AB509F01CA}", "@IfCompoundExpressionAchievementName",
        AchievementDescription = "@IfCompoundExpressionAchievementDescription",
        AchievementCategory = "@Expressions")]
    public class IfCompoundExpressionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                var condition = ifElseStatement.Condition as BinaryOperatorExpression;
                if(condition!=null && condition.Op!= BinaryOperatorType.Equality) //Tim: mmm, this achievements needs more testing because this doens't work right 
                    UnlockWith(ifElseStatement);

                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}