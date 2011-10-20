using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{BBBA5D0B-67B3-4DEB-B5AF-D27E74F963BB}", "@CreateBaseConstructorInitAchievementName",
        AchievementDescription = "@CreateBaseConstructorInitAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}", "{182BDE37-2BF4-4BB3-A8F5-CBF83D8C4850}"
                })]
    public class CreateBaseConstructorInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                if (!constructorDeclaration.Initializer.IsNull && constructorDeclaration.Initializer.ConstructorInitializerType == ConstructorInitializerType.Base)
                    UnlockWith(constructorDeclaration);

                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}