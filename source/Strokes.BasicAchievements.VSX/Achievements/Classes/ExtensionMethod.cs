using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Extended!", AchievementDescription = "Create an extension method", AchievementCategory = "Basic Achievements")]
    public class ExtensionMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.IsExtensionMethod)
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }

        }
    }
}