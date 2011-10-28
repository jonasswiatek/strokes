using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0ef2e141-458d-4e24-87ac-30a3d541d36a}", "@CreateDelegateAchievementName",
        AchievementDescription = "@CreateDelegateAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/900fyy8e(v=VS.100).aspx",
        AchievementCategory = "@EventsThreads")]
    public class CreateDelegateAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, object data)
            {
                UnlockWith(delegateDeclaration);

                return base.VisitDelegateDeclaration(delegateDeclaration, data);
            }
        }
    }
}