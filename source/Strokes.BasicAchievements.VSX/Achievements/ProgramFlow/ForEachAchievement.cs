using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Foreach loop", AchievementDescription = "Use a foreach loop",
        AchievementCategory = "Program flow")]
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