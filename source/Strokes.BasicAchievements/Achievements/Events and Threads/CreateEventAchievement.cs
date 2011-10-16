using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{85023aba-17a3-42dc-8a8d-4423a53dbe83}", "@CreateEventAchievementName",
        AchievementDescription = "@CreateEventAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class CreateEventAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
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