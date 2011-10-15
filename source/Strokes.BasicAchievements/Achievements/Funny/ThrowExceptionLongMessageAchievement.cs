using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Parser;
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
                if(throwStatement.Expression is ObjectCreateExpression)
                {
                    ObjectCreateExpression expr = (ObjectCreateExpression) throwStatement.Expression;
                    if (expr.CreateType.Type.Contains("Exception"))
                    {
                        foreach (var expression in expr.Parameters)
                        {
                            if(expression is PrimitiveExpression)
                            {
                                PrimitiveExpression prim = (PrimitiveExpression) expression;
                                if (prim.LiteralFormat == LiteralFormat.StringLiteral && prim.Value.ToString().Length > 60)
                                    UnlockWith(throwStatement);
                            }
                        }
                        UnlockWith(throwStatement);
                    }
                }
                return base.VisitThrowStatement(throwStatement, data);
            }
        }
    }
}