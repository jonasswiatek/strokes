using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{79B84B4F-AF59-427F-9254-CC86C70D23D7}", "@EnumInitializerExplicitAchievementName",
        AchievementDescription = "@EnumInitializerExplicitAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class EnumInitializerExplicitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration, object data)
            {
                if(!enumMemberDeclaration.Initializer.IsNull)
                {
                    UnlockWith(enumMemberDeclaration.Initializer);
                }
                return base.VisitEnumMemberDeclaration(enumMemberDeclaration, data);
            }
        }
    }
}