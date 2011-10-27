using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{895ea2c7-75aa-4dee-8944-4bb1d749509b}", "@SealedMethodAchievementName",
        AchievementDescription = "@SealedMethodAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms173150.aspx",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}","{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
                })]

    public class SealedMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Modifiers.HasFlag(Modifiers.Sealed))
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}