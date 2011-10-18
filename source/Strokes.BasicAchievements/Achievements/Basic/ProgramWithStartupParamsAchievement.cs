using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{01C68FE8-2A7C-4E40-842A-E407B91D2C4C}", "@ProgramWithStartupParamsAchievementName",
        AchievementDescription = "@ProgramWithStartupParamsAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ProgramWithStartupParamsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main"))
                {
                    if (!methodDeclaration.IsExtensionMethod && methodDeclaration.Modifiers.HasFlag(Modifiers.Static) && methodDeclaration.ReturnType.ToString() == "void")
                    {
                        var firstParam = methodDeclaration.Parameters.FirstOrDefault();

                        if(firstParam != null && firstParam.Type.ToString().ToLower() == "string[]")
                        {
                            var argsName = firstParam.Name;
                            var bodyCode = methodDeclaration.Body.ToString();
                            if(Regex.IsMatch(bodyCode, argsName + @"\s\[\d+\]"))
                            {
                                UnlockWith(firstParam);
                            }
                        }
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}