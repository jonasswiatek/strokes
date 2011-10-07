using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{16E54EE2-BFC4-4350-97F3-F98E92B1C8D3}", "@InstantiateObjectAchievementName",
        AchievementDescription = "@InstantiateObjectAchievementDescription",
        AchievementCategory = "@Class")]
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