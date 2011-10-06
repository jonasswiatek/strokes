using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@TypeOfAchievementName",
        AchievementDescription = "@TypeOfAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class TypeOfAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitTypeOfExpression(TypeOfExpression typeOfExpression, object data)
            {
                UnlockWith(typeOfExpression);
                return base.VisitTypeOfExpression(typeOfExpression, data);
            }

        }
    }
}