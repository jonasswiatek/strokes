using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{106AA91A-C351-41F7-9F19-1EC599320306}", "@CreateClassAchievementName",
        AchievementDescription = "@CreateClassAchievementDescription",
        AchievementCategory = "@Class")]
    public class CreateClassAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if(typeDeclaration.ClassType == ClassType.Class && typeDeclaration.Name != "Program")
                    UnlockWith(typeDeclaration);

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}