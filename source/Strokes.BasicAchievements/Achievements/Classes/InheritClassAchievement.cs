using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0ec683c7-8005-4da1-abf9-7d027ec1256f}", "@InheritClassAchievementName",
        AchievementDescription = "@InheritClassAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{106AA91A-C351-41F7-9F19-1EC599320306}"
                })]
    public class InheritClassAchievement : NRefactoryAchievement
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
                    var interfaceMarker = typeDeclaration.BaseTypes.OfType<MemberType>().FirstOrDefault();
                    if (interfaceMarker != null)
                    {
                        UnlockWith(interfaceMarker);
                    }
                }
                
                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}