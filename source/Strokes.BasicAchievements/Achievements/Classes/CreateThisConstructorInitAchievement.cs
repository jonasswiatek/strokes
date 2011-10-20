using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{DB056781-A107-4396-8D33-A9B94F0C05A3}", "@CreateThisConstructorInitAchievementName",
        AchievementDescription = "@CreateThisConstructorInitAchievementDescription",
         AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{182BDE37-2BF4-4BB3-A8F5-CBF83D8C4850}"
                })]
    public class CreateThisConstructorInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                if (constructorDeclaration.Initializer.ConstructorInitializerType == ConstructorInitializerType.This)
                    UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}