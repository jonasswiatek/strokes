using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{3CB25EA4-3DE4-4ADC-A5F4-183ACF4E1820}", "@JaggedArrayAchievementName",
        AchievementDescription = "@JaggedArrayAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class JaggedArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.IsArrayType && localVariableDeclaration.TypeReference.RankSpecifier.Length >1) //Tim= not so happy about hardocing this RankSpecifier, not sure when this specifier contains more than 1 element
                    UnlockWith(localVariableDeclaration);
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}