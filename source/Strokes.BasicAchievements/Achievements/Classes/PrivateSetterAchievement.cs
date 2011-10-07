using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{E883467B-9B20-429F-B091-9B31F37B7D0F}", "@PrivateSetterAchievementName",
        AchievementDescription = "@PrivateSetterAchievementDescription",
        AchievementCategory = "@Class")]
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