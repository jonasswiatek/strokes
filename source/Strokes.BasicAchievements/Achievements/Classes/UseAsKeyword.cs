using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A7B577B2-6ACE-4A43-94FF-33483053FCF2}", "@UseAsKeywordAchievementName",
        AchievementDescription = "@UseAsKeywordAchievementDescription",
        AchievementCategory = "@Class")]
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