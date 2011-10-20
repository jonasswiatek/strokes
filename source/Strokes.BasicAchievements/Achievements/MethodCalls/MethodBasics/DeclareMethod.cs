using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{14DEE0A5-8D80-461D-AE99-B09627B27CE6}", "@CreateMethodAchievementName",
        AchievementDescription = "@CreateMethodAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodAchievement : NRefactoryAchievement
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
                        UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}