using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0F7D9D7E-8FEE-4981-842A-4F25E2F4E2CE}", "@CreateSingleLineMethodAchievementName",
        AchievementDescription = "@CreateSingleLineMethodAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms173114(v=vs.80).aspx",
        AchievementCategory = "@Method")]
    public class CreateSingleLineMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main"))
                {
                    if (!methodDeclaration.IsExtensionMethod &&
                        !methodDeclaration.HasModifier(Modifiers.Abstract))
                    {
                        if (methodDeclaration.Body.Statements.Count() == 1 &&
                            methodDeclaration.Body.Statements.First() is ReturnStatement)
                        {
                            UnlockWith(methodDeclaration);
                        }
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}