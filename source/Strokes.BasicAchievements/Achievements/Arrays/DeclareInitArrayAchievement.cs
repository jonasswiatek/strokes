using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{2EF5C718-C944-40A0-AFDD-8142B6E15A42}", "@DeclareInitArrayAchievementName",
        AchievementDescription = "@DeclareInitArrayAchievementDescription",
        AchievementCategory = "@Arrays",
        DependsOn = new[]
                        {
                            "{B012CA29-340C-47D0-8D39-E2F83FB59D1A}"
                        })]
    public class DeclareInitArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, object data)
            {
                if(arrayInitializerExpression.Parent is ArrayCreateExpression)
                {
                    UnlockWith(arrayInitializerExpression);
                }
                
                return base.VisitArrayInitializerExpression(arrayInitializerExpression, data);
            }
        }
    }
}