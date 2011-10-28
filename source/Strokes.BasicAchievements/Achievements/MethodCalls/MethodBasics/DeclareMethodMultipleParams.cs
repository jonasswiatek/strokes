using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{936D7FC3-8548-40C9-8035-599BF3A0B594}", "@CreateMethodMultipleParametersAchievementName",
        AchievementDescription = "@CreateMethodMultipleParametersAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms173114(v=vs.80).aspx",
        AchievementCategory = "@Method")]
    public class CreateMethodMultipleParametersAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main") == false)
                {
                    if (methodDeclaration.IsExtensionMethod == false &&
                        methodDeclaration.HasModifier(Modifiers.Abstract) == false)
                    {
                        if (methodDeclaration.Parameters.Count >= 2)
                            UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{07E52DB7-CAD7-4177-A413-3C9C5E5D17D2}", "@CreateMethodOneParameterAchievementName",
        AchievementDescription = "@CreateMethodOneParameterAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodOneParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main") == false)
                {
                    if (methodDeclaration.IsExtensionMethod == false &&
                        methodDeclaration.HasModifier(Modifiers.Abstract) == false)
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