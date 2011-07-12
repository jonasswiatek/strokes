using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Objectivy!", AchievementDescription = "Create an object", AchievementCategory = "Basic Achievements")]
    public class InstantiateObjectAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
            {
                UnlockWith(objectCreateExpression);
                return base.VisitObjectCreateExpression(objectCreateExpression, data);
            }
        }
    }
}