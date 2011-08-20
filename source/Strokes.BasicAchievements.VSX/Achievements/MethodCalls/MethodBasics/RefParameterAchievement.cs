using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Ref Parameter", AchievementDescription = "Write a method that uses the ref keyword in its arguments", AchievementCategory = "Method")]
    public class RefParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitParameterDeclarationExpression(ParameterDeclarationExpression parameterDeclarationExpression, object data)
            {
                if (parameterDeclarationExpression.ParamModifier == ParameterModifiers.Ref)
                {
                    UnlockWith(parameterDeclarationExpression);
                }
                return base.VisitParameterDeclarationExpression(parameterDeclarationExpression, data);
            }
        }
    }
}