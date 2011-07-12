using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Define equality", AchievementDescription = "Override System.Object.Equals", AchievementCategory = "Basic Achievements")]
    public class OverrideEqualsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name == "Equals" && methodDeclaration.Modifier.HasFlag(Modifiers.Override) && methodDeclaration.TypeReference.Type == "System.Boolean" )
                {
                    if (methodDeclaration.Parameters.Count == 1) //Just to be certain
                    {
                        if(methodDeclaration.Parameters[0].TypeReference.Type=="System.Object" && methodDeclaration.Parameters[0].ParameterName=="obj")
                            UnlockWith(methodDeclaration);
                    }
                    
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }

        }
    }
}