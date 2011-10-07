using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{3CB25EA4-3DE4-4ADC-A5F4-183ACF4E1820}", "@ArrayLengthPropertyAchievementName",
        AchievementDescription = "@ArrayLengthPropertyAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class ArrayLengthPropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if (memberReferenceExpression.TargetObject is IdentifierExpression)
                {
                    var identifier = (IdentifierExpression) memberReferenceExpression.TargetObject;

                    if (identifier.Identifier == "array" && memberReferenceExpression.MemberName == "Length")
                        UnlockWith(memberReferenceExpression);

                }
                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

        }
    }
}