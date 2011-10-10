using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{C18FCAA9-454D-4A71-9CD4-19D6508EFF42}", "@DoWhileLoopAchievementName",
        AchievementDescription = "@DoWhileLoopAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class DoWhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
            {
                if (doLoopStatement.ConditionPosition == ConditionPosition.End) //DoWhile loops has their condition at ConditionPosition.End, while has it at ConditionPosition.Start.
                {
                    UnlockWith(doLoopStatement);
                }

                return base.VisitDoLoopStatement(doLoopStatement, data);
            }
        }
    }
}