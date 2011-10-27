using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{ECCCFA7F-EAC7-41DD-B924-896326A4074D}", "@OverrideToStringAchievementName",
        AchievementDescription = "@OverrideToStringAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.object.tostring.aspx",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class OverrideToStringAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name == "ToString" && methodDeclaration.Modifiers.HasFlag(Modifiers.Override))
                {
                    var returnType = methodDeclaration.ReturnType as PrimitiveType;
                    if (returnType != null && returnType.Keyword.ToLower() == "string")
                    {
                        UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}