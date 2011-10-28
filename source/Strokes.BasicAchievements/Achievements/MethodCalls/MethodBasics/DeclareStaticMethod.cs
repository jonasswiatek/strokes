using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0414EFDB-0865-4E3C-9809-B779EA1F6CCF}", "@CreateStaticMethodAchievementName",
        AchievementDescription = "@CreateStaticMethodAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/79b3xss3(v=VS.100).aspx",
        AchievementCategory = "@Method")]
    public class CreateStaticMethodAchievement : NRefactoryAchievement
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
                        if (methodDeclaration.Modifiers.HasFlag(Modifiers.Static))
                            UnlockWith(methodDeclaration);
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}