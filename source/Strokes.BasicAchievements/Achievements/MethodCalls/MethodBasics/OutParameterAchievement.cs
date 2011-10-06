using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@OutParameterAchievementName",
        AchievementDescription = "@OutParameterAchievementDescription",
        AchievementCategory = "@Method")]
    public class OutParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitParameterDeclarationExpression(ParameterDeclarationExpression parameterDeclarationExpression, object data)
            {
                if (parameterDeclarationExpression.ParamModifier == ParameterModifiers.Out)
                {
                    UnlockWith(parameterDeclarationExpression);
                }
                return base.VisitParameterDeclarationExpression(parameterDeclarationExpression, data);
            }
        }
    }
}