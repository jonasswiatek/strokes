using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{9656305D-D26E-4B7D-AB51-8585A8FCA3CF}", "@CreatePropertyAchievementName",
        AchievementDescription = "@CreatePropertyAchievementDescription",
        AchievementCategory = "@Class")]
    public class CreatePropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
            {
                UnlockWith(propertyDeclaration);

                return base.VisitPropertyDeclaration(propertyDeclaration, data);
            }
        }
    }
}