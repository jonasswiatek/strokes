using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Use compound expression in if statement", AchievementDescription = "Make use of multiple expression in one if statement (usage of &&,||, etc. operators)",
        AchievementCategory = "Basic Achievements")]
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
                if(condition!=null)
                    IsAchievementUnlocked = true;
                return base.VisitIfElseStatement(ifElseStatement, data);
            } 


        }
    }
}