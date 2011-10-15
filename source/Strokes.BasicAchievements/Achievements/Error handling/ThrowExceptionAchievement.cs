using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
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
                    ObjectCreateExpression expr = (ObjectCreateExpression) throwStatement.Expression;
                    if(expr.CreateType.Type.Equals("Exception"))
                        UnlockWith(throwStatement);
                }
                return base.VisitThrowStatement(throwStatement, data);
            }
        }
    }
}