using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@CreateBaseConstructorInitAchievementName",
        AchievementDescription = "@CreateBaseConstructorInitAchievementDescription",
        AchievementCategory = "@Class")]
    public class CreateBaseConstructorInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                if (constructorDeclaration.ConstructorInitializer.ConstructorInitializerType == ConstructorInitializerType.Base)
                    UnlockWith(constructorDeclaration);

                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}