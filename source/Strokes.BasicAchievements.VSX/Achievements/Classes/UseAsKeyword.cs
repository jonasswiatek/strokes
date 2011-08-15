using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("As", AchievementDescription = "Try explicit cast with AS keyword", AchievementCategory = "Class")]
    public class UseAsKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitCastExpression(CastExpression castExpression, object data)
            {
                if (castExpression.CastType == CastType.TryCast)
                    UnlockWith(castExpression);
                return base.VisitCastExpression(castExpression, data);
            }
        }
    }
}