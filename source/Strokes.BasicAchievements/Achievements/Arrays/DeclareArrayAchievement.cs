using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B012CA29-340C-47D0-8D39-E2F83FB59D1A}", "@DeclareArrayAchievementName",
        AchievementDescription = "@DeclareArrayAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class DeclareArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* REFACTOR
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.IsArrayType)
                    UnlockWith(localVariableDeclaration);
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }*/
        }
    }
}