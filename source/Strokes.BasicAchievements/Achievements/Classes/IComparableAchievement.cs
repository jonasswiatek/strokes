using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{193657CA-35AC-44C3-89CB-E376C97F0B2C}", "@IComparableAchievementName",
        AchievementDescription = "@IComparableAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class IComparableAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.ClassType == ClassType.Class)
                {
                    var iComparableMarker = typeDeclaration.BaseTypes.OfType<SimpleType>().FirstOrDefault(a => a.Identifier.EndsWith("IComparable"));
                    if (iComparableMarker != null)
                    {
                        UnlockWith(iComparableMarker);
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}