using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@DeclareMultipleDimArrayAchievementName", 
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