using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Prop [tab][tab]",
        AchievementDescription = "Create an auto property ",
        AchievementCategory = "Basic Achievements")]
    public class CreateAutoPropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
            {

                if (propertyDeclaration.GetRegion.Block.IsNull == true && propertyDeclaration.SetRegion.Block.IsNull)
                    UnlockWith(propertyDeclaration);

                return base.VisitPropertyDeclaration(propertyDeclaration, data);
            }
        }
    }
}