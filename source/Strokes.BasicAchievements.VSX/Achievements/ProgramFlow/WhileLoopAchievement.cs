using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("While loop", AchievementDescription = "Use a while loop",
        AchievementCategory = "Basic Achievements")]
    public class WhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                if (doLoopStatement.ConditionPosition == ConditionPosition.Start) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
                {
                    IsAchievementUnlocked = true;
                }

                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
        }
    }
}