using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{85023aba-17a3-42dc-8a8d-4423a53dbe83}", "@CreateEventAchievementName",
        AchievementDescription = "@CreateEventAchievementDescription",
        AchievementCategory = "@Events")]
    public class CreateEventAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitEventDeclaration(EventDeclaration eventDeclaration, object data)
            {
                UnlockWith(eventDeclaration);
                return base.VisitEventDeclaration(eventDeclaration, data);
            }
        }
    }
}