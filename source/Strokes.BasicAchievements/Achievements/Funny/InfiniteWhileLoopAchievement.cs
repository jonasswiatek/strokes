using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{19F147D7-63B7-40B2-8863-A8CEF0E162F8}", "@InfiniteWhileLoopAchievementName",
        AchievementDescription = "@InfiniteWhileLoopAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{E61CFC56-7F74-48B9-A19A-FB414D35CA6B}"
        })]
    public class InfiniteWhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                if (doLoopStatement.ConditionPosition == ConditionPosition.Start)
                {
                    var condition = doLoopStatement.Condition as PrimitiveExpression;
                    if (condition != null && condition.StringValue == "true")
                    {
                        UnlockWith(doLoopStatement);
                    }
                }

                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
        }
    }
}