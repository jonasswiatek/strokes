using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@VirtualMethodAchievementName",
        AchievementDescription = "@VirtualMethodAchievementDescription",
        AchievementCategory = "@Class")]
    public class VirtualMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if(methodDeclaration.Modifier.HasFlag(Modifiers.Virtual))
                    UnlockWith(methodDeclaration);
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescription("Override!", AchievementDescription = "Override a method", AchievementCategory = "@Class")]
    public class OVerrideMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Modifier.HasFlag(Modifiers.Override))
                    UnlockWith(methodDeclaration);
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}