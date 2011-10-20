using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{E883467B-9B20-429F-B091-9B31F37B7D0F}", "@PrivateSetterAchievementName",
        AchievementDescription = "@PrivateSetterAchievementDescription",
        AchievementCategory = "@Class")]
    public class PrivateSetterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
            {
                if (propertyDeclaration.Setter.Modifiers.HasFlag(Modifiers.Private))
                {
                    UnlockWith(propertyDeclaration.Setter);
                }

                return base.VisitPropertyDeclaration(propertyDeclaration, data);
            }
        }
    }
}