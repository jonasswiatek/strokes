using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@CreateMethodMultipleParametersAchievementName",
        AchievementDescription = "@CreateMethodMultipleParametersAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodMultipleParametersAchievement : NRefactoryAchievement
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
                        if(methodDeclaration.Parameters.Count>=2)
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescription("Method man and a friend", 
        AchievementDescription = "Create a method with 1 parameter", 
        AchievementCategory = "@Method")]
    public class CreateMethodOneParameterAchievement : NRefactoryAchievement
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
                        if (methodDeclaration.Parameters.Count == 1)
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}