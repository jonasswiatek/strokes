using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{2b8768da-1ffc-49a3-a3d6-50a69995cf2c}", "@ThrowExceptionAchievementName",
        AchievementDescription = "@ThrowExceptionAchievementDescription",
        AchievementCategory = "@ErrorHandling")]
    public class ThrownExceptionAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitThrowStatement(ThrowStatement throwStatement, object data)
            {
                if(throwStatement.Expression is ObjectCreateExpression)
                {
                    var expr = (ObjectCreateExpression) throwStatement.Expression;
                    var typeRef = expr.Type as SimpleType;
                    
                    if(typeRef != null)
                    {
                        UnlockWith(throwStatement.Expression);
                    }
                }
                return base.VisitThrowStatement(throwStatement, data);
            }
        }
    }
}