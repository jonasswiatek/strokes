using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{CD562B17-558E-4D7B-AF04-31C47BAE91FB}", "@OverrideEqualsAchievementName",
        AchievementDescription = "@OverrideEqualsAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class OverrideEqualsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* REFACTOR
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
            */
        }
    }
}