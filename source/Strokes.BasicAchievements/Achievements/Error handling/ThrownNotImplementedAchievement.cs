using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{fc2721c2-8bc8-4638-b696-66b4688df064}", "@ThrownNotImplementedAchievementName",
        AchievementDescription = "@ThrownNotImplementedAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class ThrownNotImplementedAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* //REFACTOR
            public override object VisitThrowStatement(ThrowStatement throwStatement, object data)
            {
                if(throwStatement.Expression is ObjectCreateExpression)
                {
                    ObjectCreateExpression expr = (ObjectCreateExpression) throwStatement.Expression;
                    if(expr.CreateType.Type.Equals("NotImplementedException"))
                        UnlockWith(throwStatement);
                }
                return base.VisitThrowStatement(throwStatement, data);
            }
             */
        }
    }
}