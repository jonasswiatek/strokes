using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{1B9C1201-E2A9-4FE6-A8A6-44ABE06517FD}", "@EnumInitializerAchievementName",
        AchievementDescription = "@EnumInitializerAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class EnumInitializerAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.ClassType == ClassType.Enum)
                {
                    UnlockWith(typeDeclaration);
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}