using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{579E6C20-29FE-4D54-A2F0-4D80DAD93F8E}", "@DeclareMultipleDimArrayAchievementName", 
        AchievementDescription = "@DeclareMultipleDimArrayAchievementDescription", 
        AchievementCategory = "@Arrays")]
    public class DeclareMultipleDimArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                //Tim= not so happy about hardocing this RankSpecifier, not sure when this specifier contains more than 1 element
                if (localVariableDeclaration.TypeReference.IsArrayType && localVariableDeclaration.TypeReference.RankSpecifier[0]>=1) 
                    UnlockWith(localVariableDeclaration);

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}