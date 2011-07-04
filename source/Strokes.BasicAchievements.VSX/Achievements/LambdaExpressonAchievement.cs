using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Lambda Expression", AchievementDescription = "Use a lambda expression", AchievementCategory = "Basic Achievements")]
    public class LambdaExpressonAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLambdaExpression(LambdaExpression lambdaExpression, object data)
            {
                IsAchievementUnlocked = true;
                return base.VisitLambdaExpression(lambdaExpression, data);
            }
        }
    }
}