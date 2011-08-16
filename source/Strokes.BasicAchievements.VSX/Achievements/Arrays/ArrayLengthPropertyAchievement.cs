using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Array length", AchievementDescription = "Use the Length property of an array", AchievementCategory = "Arrays")]
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
                if (memberReferenceExpression.MemberName == "Length") //Tim: not 100% ok, will trigger any .Length usage...So needs to check if TargetObject is in fact an array..Not sure how that works
                    UnlockWith(memberReferenceExpression);
                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

        }
    }
}