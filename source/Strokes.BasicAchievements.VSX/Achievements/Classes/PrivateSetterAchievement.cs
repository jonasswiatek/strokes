using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Private Setter",
        AchievementDescription = "Write a property of any type with a private setter",
        AchievementCategory = "Class")]
    public class PrivateSetterAchievement : NRefactoryAchievement
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