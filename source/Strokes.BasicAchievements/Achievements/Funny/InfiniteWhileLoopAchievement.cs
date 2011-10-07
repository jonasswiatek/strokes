using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{19F147D7-63B7-40B2-8863-A8CEF0E162F8}", "@InfiniteWhileLoopAchievementName",
        AchievementDescription = "@InfiniteWhileLoopAchievementDescription",
        AchievementCategory = "@Funny")]
    public class InfiniteWhileLoopAchievement : NRefactoryAchievement
    {
        //Abstract method enforced by the base-class
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            //This creates an instance of the private class "Visitor" inside this class.
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            // This method gets called by NRefactory whenever it encounters a while or do-while loop in the source code it's "walking"
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                //While loops have their ConditionPosition at the START (do while has it at END).
                if (doLoopStatement.ConditionPosition == ConditionPosition.Start) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
                {
                    /* Format of a while-loop:
                     * while(condition)
                     * {
                     *      EmbeddedStatement (block)
                     * }
                     * Condition can be several things:
                     * "true" or "a > b" is a "PrimitiveExpression". If it looked like this: while(GetBool()) { }, it could also be an InvocationExpression. 
                     */

                    //Get the condition, as a PrimitiveCondition. I condition == null after this, then it wasn't a PrimitiveExpression, but a method call (InvocationExpression)
                    var condition = doLoopStatement.Condition as PrimitiveExpression;
                    if(condition != null && condition.StringValue == "true") //We could also do: if(condition != null && (bool)condition.Value)
                    {
                        //Set this bool-member to true, to signal to the base class that this achievement's conditions have been met.
                        UnlockWith(doLoopStatement);
                    }
                }

                //Always return this at the end of the method. It can break the walk-chain otherwise.
                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
        }
    }
}