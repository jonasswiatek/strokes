using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{1D2171F4-9D57-4EA7-8B61-C493FC1F8DFC}", "@TooManyDimensionArrayDeclarationAchievementName",
        AchievementDescription = "@TooManyDimensionArrayDeclarationAchievementDescription",
        AchievementCategory = "@Funny")]
    public class TooManyDimensionArrayDeclarationAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.IsArrayType && localVariableDeclaration.TypeReference.RankSpecifier[0]>10) //Tim= not so happy about hardocing this RankSpecifier, not sure when this specifier contains more than 1 element
                    UnlockWith(localVariableDeclaration);
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}