using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{0ef2e141-458d-4e24-87ac-30a3d541d36a}", "@CreateDelegateAchievementName",
        AchievementDescription = "@CreateDelegateAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class CreateDelegateAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
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