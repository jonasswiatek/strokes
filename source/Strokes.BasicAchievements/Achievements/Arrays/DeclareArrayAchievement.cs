using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B012CA29-340C-47D0-8D39-E2F83FB59D1A}", "@DeclareArrayAchievementName",
        AchievementDescription = "@DeclareArrayAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class DeclareArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
            {
                UnlockWith(arraySpecifier);
                return base.VisitArraySpecifier(arraySpecifier, data);
            }
        }
    }
}