using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("That's tiny", AchievementDescription = "Create a method that only contains one single return expression", AchievementCategory = "Method")]
    public class CreateSingleLineMethodAchievement : NRefactoryAchievement
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
                        if(methodDeclaration.Body.Children.Count==1 && methodDeclaration.Body.Children[0] is ReturnStatement)
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}