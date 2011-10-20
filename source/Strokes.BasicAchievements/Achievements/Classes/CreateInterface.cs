using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{90406D2E-575C-4A57-AF4F-028361C575D0}", "@CreateInterfaceAchievementName",
        AchievementDescription = "@CreateInterfaceAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class CreateInterfaceAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if(typeDeclaration.ClassType == ClassType.Interface)
                    UnlockWith(typeDeclaration);

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}