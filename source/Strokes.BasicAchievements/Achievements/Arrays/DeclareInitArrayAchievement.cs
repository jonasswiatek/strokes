using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

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
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private int lastSpecifierLine = 0;
            public override object VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
            {
                lastSpecifierLine = arraySpecifier.StartLocation.Line;

                return base.VisitArraySpecifier(arraySpecifier, data);
            }
            public override object VisitArrayInitializerExpression(ICSharpCode.NRefactory.CSharp.ArrayInitializerExpression arrayInitializerExpression, object data)
            {
                //TODO: This ain't pretty - there is no C# requirement that the specifier and initializer must be on the same line.
                if(arrayInitializerExpression.StartLocation.Line == lastSpecifierLine)
                {
                    UnlockWith(arrayInitializerExpression);
                }
                
                return base.VisitArrayInitializerExpression(arrayInitializerExpression, data);
            }
        }
    }
}