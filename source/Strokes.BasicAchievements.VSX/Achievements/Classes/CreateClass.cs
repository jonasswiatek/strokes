using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Classy!", AchievementDescription = "Create a class", AchievementCategory = "Basic Achievements")]
    public class CreateClassAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if(typeDeclaration.Type== ClassType.Class && typeDeclaration.Name!="Program")
                    UnlockWith(typeDeclaration);
                return base.VisitTypeDeclaration(typeDeclaration, data);
            }

        }
    }
}