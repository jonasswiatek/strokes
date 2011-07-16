using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Create object with initializers", AchievementDescription = "Create an object using object initializer notation", AchievementCategory = "Basic Achievements")]
    public class InstantiateObjectWithInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
            {
                var expr = objectCreateExpression.ObjectInitializer;

                if (expr.CreateExpressions.Count > 0 && !objectCreateExpression.IsAnonymousType)
                    UnlockWith(objectCreateExpression.ObjectInitializer); //Handing over the ObjectInitializer will make it highlight that code region only.

                return base.VisitObjectCreateExpression(objectCreateExpression, data);
            }
        }
    }
}