using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{EF26B754-4331-434F-817B-49C1C49E11E9}", "@CreateAutoPropertyAchievementName",
        AchievementDescription = "@CreateAutoPropertyAchievementDescription",
        AchievementCategory = "@Class")]
    public class CreateAutoPropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
            {

                if (propertyDeclaration.GetRegion.Block.IsNull && propertyDeclaration.SetRegion.Block.IsNull)
                    UnlockWith(propertyDeclaration);

                return base.VisitPropertyDeclaration(propertyDeclaration, data);
            }
        }
    }
}