using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Or else what?!", AchievementDescription = "Make use of an if/else statement",
        AchievementCategory = "Basic Achievements")]
    public class IfElseStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                if(ifElseStatement.HasElseStatements)
                    UnlockWith(ifElseStatement);

                return base.VisitIfElseStatement(ifElseStatement, data);
            } 

            //public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            //{
            //    if (doLoopStatement.ConditionPosition == ConditionPosition.Start) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
            //    {
            //        IsAchievementUnlocked = true;
            //    }

            //    return base.VisitDoLoopStatement(doLoopStatement, data);
            //}
        }
    }
}