using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{8f7e75c9-d965-44f9-a579-fe7f6c829ed3}", "@EmptyMainAchievementName",
        AchievementDescription = "@EmptyMainAchievementDescription",
        HintUrl = "http://blanksite.com/",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
        })]
    public class EmptyMainAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.Equals("Main"))
                {
                    if (!methodDeclaration.Body.Statements.Any())
                        UnlockWith(methodDeclaration);
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{00dcc080-76e8-4953-a036-f35ea2b3c77d}", "@EmptyMethodAchievementName",
        AchievementDescription = "@EmptyMethodAchievementDescription",
        HintUrl = "http://blanksite.com/",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
        })]
    public class EmptyMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Body != null)
                {
                    if (methodDeclaration.Body.Children.Count() == 0)
                        UnlockWith(methodDeclaration);
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{b752b0bd-9942-4602-ae02-8c78ad2b76bb}", "@EmptyVoidMethodAchievementName",
        AchievementDescription = "@EmptyVoidMethodAchievementDescription",
        HintUrl = "http://blanksite.com/",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
        })]
    public class EmptyVoidMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Body != null && methodDeclaration.ReturnType.ToString() == "void")
                {
                    if (methodDeclaration.Body.Statements.Count == 0)
                        UnlockWith(methodDeclaration);
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}