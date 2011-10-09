using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{80034460-25A1-4BAB-9C23-B6C0C6CACE71}", "@AbstractMethodAchievementName",
        AchievementDescription = "@AbstractMethodAchievementDescription",
        AchievementCategory = "@Class")]
    public class AbstractMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}