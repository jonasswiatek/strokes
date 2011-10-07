using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{FDCBFA55-8DE1-4E35-B924-AA9DB88AEF4D}", "@UseIsKeywordAchievementName",
        AchievementDescription = "@UseIsKeywordAchievementDescription",
        AchievementCategory = "@Class")]
    public class UseIsKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeOfIsExpression(TypeOfIsExpression typeOfIsExpression, object data)
            {
                UnlockWith(typeOfIsExpression);
                return base.VisitTypeOfIsExpression(typeOfIsExpression, data);
            }
        }
    }
}