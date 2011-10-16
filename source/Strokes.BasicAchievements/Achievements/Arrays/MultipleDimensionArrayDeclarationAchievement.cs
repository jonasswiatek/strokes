using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{579E6C20-29FE-4D54-A2F0-4D80DAD93F8E}", "@DeclareMultipleDimArrayAchievementName", 
        AchievementDescription = "@DeclareMultipleDimArrayAchievementDescription",
        AchievementCategory = "@Arrays",
        DependsOn = new[]
                        {
                            "{B012CA29-340C-47D0-8D39-E2F83FB59D1A}"
                        })]
    public class DeclareMultipleDimArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* REFACTOR: This visitor method doesn't exist in NRefactory 5
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                //Tim= not so happy about hardocing this RankSpecifier, not sure when this specifier contains more than 1 element
                if (localVariableDeclaration.TypeReference.IsArrayType && localVariableDeclaration.TypeReference.RankSpecifier[0]>=1) 
                    UnlockWith(localVariableDeclaration);

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }*/
        }
    }
}