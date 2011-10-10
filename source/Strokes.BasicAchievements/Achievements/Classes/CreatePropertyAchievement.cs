using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{9656305D-D26E-4B7D-AB51-8585A8FCA3CF}", "@CreatePropertyAchievementName",
        AchievementDescription = "@CreatePropertyAchievementDescription",
        AchievementCategory = "@Class")]
    public class CreatePropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
            {
                if ((propertyDeclaration.SetRegion.Modifier & Modifiers.Private) == Modifiers.Private)
                {
                    UnlockWith(propertyDeclaration.SetRegion);
                }

                return base.VisitPropertyDeclaration(propertyDeclaration, data);
            }
        }
    }
}