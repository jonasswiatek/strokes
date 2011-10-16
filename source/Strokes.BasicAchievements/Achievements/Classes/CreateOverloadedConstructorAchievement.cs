using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{4F93ECDB-F307-4C41-9F49-A84813096016}", "@CreateOverloadedConstructorAchievementName",
        AchievementDescription = "@CreateOverloadedConstructorAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{182BDE37-2BF4-4BB3-A8F5-CBF83D8C4850}"
                })]
    public class CreateOverloadedConstructorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
            {
                if(constructorDeclaration.Parameters.Count>0)
                    UnlockWith(constructorDeclaration);
                return base.VisitConstructorDeclaration(constructorDeclaration, data);
            }
        }
    }
}