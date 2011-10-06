using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@CreatePropertyAchievementName",
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