using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Interface", AchievementDescription = "Create an interface", AchievementCategory = "Basic Achievements")]
    public class CreateInterfaceAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if(typeDeclaration.Type== ClassType.Interface)
                    UnlockWith(typeDeclaration);
                return base.VisitTypeDeclaration(typeDeclaration, data);
            }

        }
    }
}