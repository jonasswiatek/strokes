using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("For loop", AchievementDescription = "Use a for loop", AchievementCategory = "Basic Achievements")]
    public class ForAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitForStatement(ForStatement forStatement, object data)
            {
                UnlockWith(forStatement);

                return base.VisitForStatement(forStatement, data);
            }
        }
    }
}