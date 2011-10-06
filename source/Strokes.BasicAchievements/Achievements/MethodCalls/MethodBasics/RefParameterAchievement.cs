using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@RefParameterAchievementName",
        AchievementDescription = "@RefParameterAchievementDescription",
        AchievementCategory = "@Method")]
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