using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A7B577B2-6ACE-4A43-94FF-33483053FCF2}", "@UseAsKeywordAchievementName",
        AchievementDescription = "@UseAsKeywordAchievementDescription",
        AchievementCategory = "@Class")]
    public class UseAsKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* //REFACTOR
            public override object VisitCastExpression(CastExpression castExpression, object data)
            {
                if (castExpression.CastType == CastType.TryCast)
                    UnlockWith(castExpression);
                return base.VisitCastExpression(castExpression, data);
            }
             */
        }
    }
}