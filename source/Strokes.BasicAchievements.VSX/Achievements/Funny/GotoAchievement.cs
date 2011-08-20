using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Spaghetti Bolognese ", AchievementDescription = "Please don't use goto anymore. You've got the achievement, happy now?", AchievementCategory = "Funny")]
    public class GotoAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitGotoStatement(GotoStatement gotoStatement, object data)
            {
                UnlockWith(gotoStatement);

                return base.VisitGotoStatement(gotoStatement, data);
            }
        }
    }
}