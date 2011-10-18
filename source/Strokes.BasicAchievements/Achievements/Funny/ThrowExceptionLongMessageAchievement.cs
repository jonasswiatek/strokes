using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{a2a83b00-af24-440d-8a51-cdb6837035b1}", "@ThrowExceptionLongMessageAchievementName",
        AchievementDescription = "@ThrowExceptionLongMessageAchievementDescription",
        AchievementCategory = "@Funny")]
    public class ThrowExceptionLongMessageAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitThrowStatement(ThrowStatement throwStatement, object data)
            {
                var createExpression = throwStatement.Expression as ObjectCreateExpression;
                if (createExpression != null && createExpression.Type.GetTypeName().Contains("Exception"))
                {
                    foreach (var expression in createExpression.Arguments)
                    {
                        if (expression is PrimitiveExpression)
                        {
                            var primitiveExpression = (PrimitiveExpression)expression;
                            if (primitiveExpression.Value.ToString().Length > 60)
                                UnlockWith(throwStatement);
                        }
                    }
                }

                return base.VisitThrowStatement(throwStatement, data);
            }
        }
    }
}