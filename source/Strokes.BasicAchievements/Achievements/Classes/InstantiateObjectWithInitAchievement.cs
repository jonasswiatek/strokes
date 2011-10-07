using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{DC239C85-97E5-45FB-8F87-B95E667C0F4F}", "@InstantiateObjectWithInitAchievementName",
        AchievementDescription = "@InstantiateObjectWithInitAchievementDescription",
        AchievementCategory = "@Class")]
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