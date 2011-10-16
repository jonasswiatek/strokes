using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{3CB25EA4-3DE4-4ADC-A5F4-183ACF4E1820}", "@JaggedArrayAchievementName",
        AchievementDescription = "@JaggedArrayAchievementDescription",
        AchievementCategory = "@Arrays",
        DependsOn = new[]
                        {
                            "{B012CA29-340C-47D0-8D39-E2F83FB59D1A}"
                        })]
    public class JaggedArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private int lastArraySpecifierLine = 0;
            private int lastArraySpecifierColumn = 0;

            public override object VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
            {
                if(lastArraySpecifierLine == arraySpecifier.StartLocation.Line && lastArraySpecifierColumn == arraySpecifier.StartLocation.Column-2)
                {
                    UnlockWith(arraySpecifier);
                }

                lastArraySpecifierLine = arraySpecifier.StartLocation.Line;
                lastArraySpecifierColumn = arraySpecifier.StartLocation.Column;
                return base.VisitArraySpecifier(arraySpecifier, data);
            }
        }
    }
}