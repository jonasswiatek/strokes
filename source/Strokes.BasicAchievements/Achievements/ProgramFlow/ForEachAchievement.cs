using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{F328611E-562D-4D8B-B1AE-48830DB00C7E}", "@ForEachAchievementName",
        AchievementDescription = "@ForEachAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class ForEachAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitForeachStatement(ForeachStatement foreachStatement, object data)
            {
                UnlockWith(foreachStatement);

                return base.VisitForeachStatement(foreachStatement, data);
            }
        }
    }
}