using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{182BDE37-2BF4-4BB3-A8F5-CBF83D8C4850}", "@CreateConstructorAchievementName",
        AchievementDescription = "@CreateConstructorAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{106AA91A-C351-41F7-9F19-1EC599320306}"
                })]
    public class CreateConstructorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}