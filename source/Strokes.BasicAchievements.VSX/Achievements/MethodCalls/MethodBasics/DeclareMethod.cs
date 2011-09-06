using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Method man", AchievementDescription = "Create a method", AchievementCategory = "Method")]
    public class CreateMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {

                        UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}