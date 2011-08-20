using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Bob the Overloaded Constructor", AchievementDescription = "Write a overloaded class constructor", AchievementCategory = "Class")]
    public class CreateOverloadedConstructorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                if(constructorDeclaration.Parameters.Count>0)
                    UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}