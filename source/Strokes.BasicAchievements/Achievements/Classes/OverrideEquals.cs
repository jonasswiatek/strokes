using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

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
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if(methodDeclaration.Name == "Equals" && methodDeclaration.Modifiers.HasFlag(Modifiers.Override))
                {
                    var returnType = methodDeclaration.ReturnType as PrimitiveType;
                    if(returnType != null && returnType.Keyword == "bool")
                    {
                        UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}