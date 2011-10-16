using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B9AEEF5B-C062-4580-B9D9-842D6A53EBE7}", "@DefaultCaseInSwitchSwitchAchievementName",
        AchievementDescription = "@DefaultCaseInSwitchSwitchAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DefaultCaseInSwitchSwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            
            public override object VisitSwitchSection(SwitchSection switchSection, object data)
            {
                // REFACTOR
                // TODO: Missing a way to detect the 'default' statement.

                //var defaultLabel = switchSection.CaseLabels.FirstOrDefault(a => a.Role == );
                //if(defaultLabel != null)
                //{
                //    // Bug: For some reason this the defaultLabel here doesn't have it's lines in the source document set. Bug in NRefactory?
                //    UnlockWith(defaultLabel);

                //    IsAchievementUnlocked = true;
                //}
                
                return base.VisitSwitchSection(switchSection, data);
            }
        }
    }
}