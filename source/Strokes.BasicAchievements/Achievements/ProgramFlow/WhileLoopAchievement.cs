using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{E61CFC56-7F74-48B9-A19A-FB414D35CA6B}", "@WhileLoopAchievementName",
        AchievementDescription = "@WhileLoopAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class WhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* REFACTOR
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                if (doLoopStatement.ConditionPosition == ConditionPosition.Start) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
                {
                    UnlockWith(doLoopStatement);
                }

                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
             */
        }
    }
}