using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("ID object", AchievementDescription = "Override System.Object.GetHashCode() method", AchievementCategory = "Basic Achievements")]
    public class OverrideGetHashCodeAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name == "GetHashCode" && methodDeclaration.Modifier.HasFlag(Modifiers.Override) && methodDeclaration.TypeReference.Type == "System.Int32")
                    UnlockWith(methodDeclaration);
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }

        }
    }
}