using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{01C68FE8-2A7C-4E40-842A-E407B91D2C4C}", "@ProgramWithStartupParamsAchievementName",
        AchievementDescription = "@ProgramWithStartupParamsAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ProgramWithStartupParamsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main"))
                {
                    if (methodDeclaration.IsExtensionMethod == false &&
                        methodDeclaration.Modifiers.HasFlag(Modifiers.Static) &&
                        methodDeclaration.ReturnType.ToString() == "void")
                    {
                        var firstParam = methodDeclaration.Parameters.FirstOrDefault();

                        if (firstParam != null && firstParam.Type.ToString().ToLower() == "string[]")
                        {
                            // The following is a lesson in awesomeness: 
                            //     Get all decendants of the method declaration that are IndexerExpressions, 
                            //     which points to an identifier with the name [of our args variable]
                            var indexerIdentifierExpressions = methodDeclaration.Descendants
                                .OfType<IndexerExpression>()
                                .Select(a => a.Target)
                                .OfType<IdentifierExpression>();
                            
                            if (indexerIdentifierExpressions.Any(a => a.Identifier == firstParam.Name))
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