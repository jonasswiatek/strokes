using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Dis a constructor", AchievementDescription = "Call another constructor using the this() keyword from a constructor", AchievementCategory = "Basic Achievements")]
    public class CreateThisConstructorInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {

                if (constructorDeclaration.ConstructorInitializer.ConstructorInitializerType== ConstructorInitializerType.This)
                    UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}