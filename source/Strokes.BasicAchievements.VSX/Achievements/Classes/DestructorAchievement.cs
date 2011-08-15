using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("My name is Destructor!", AchievementDescription = "Define a destructor for your class", AchievementCategory = "Class")]
    public class DestructorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data)
            {
                UnlockWith(destructorDeclaration);
                return base.VisitDestructorDeclaration(destructorDeclaration, data);
            }

        }
    }
}