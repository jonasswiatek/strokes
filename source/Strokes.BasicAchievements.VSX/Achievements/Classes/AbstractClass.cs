using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Abstract class", AchievementDescription = "Create an abstract class", AchievementCategory = "Class")]
    public class AbstractClassAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.Type == ClassType.Class && typeDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    UnlockWith(typeDeclaration);

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}