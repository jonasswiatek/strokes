using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{58E7FA3B-E4D3-4F34-8205-F3F9FAF00E90}", "@OverrideGetHashCodeAchievementName",
        AchievementDescription = "@OverrideGetHashCodeAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class OverrideGetHashCodeAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name == "GetHashCode" && methodDeclaration.Modifiers.HasFlag(Modifiers.Override))
                {
                    var returnType = methodDeclaration.ReturnType as PrimitiveType;
                    if (returnType != null && returnType.Keyword == "int")
                    {
                        UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}