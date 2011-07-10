using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Bob the Constructor", AchievementDescription = "Write a class constructor", AchievementCategory = "Basic Achievements")]
    public class CreateConstructorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}