using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{600e9b5d-ef04-46d9-90db-3b0395c7c9a0}", "@CreateThreadAchievementName",
        AchievementDescription = "@CreateThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class CreateThreadAchievement : NRefactoryAchievement
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
                if (localVariableDeclaration.TypeReference.ToString().Equals("Thread") ||
                    localVariableDeclaration.TypeReference.ToString().Equals("Threading.Thread"))
                {
                    UnlockWith(localVariableDeclaration);
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
             */
        }
    }
}