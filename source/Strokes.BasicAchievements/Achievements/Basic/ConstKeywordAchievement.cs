using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{07D39703-8F4A-4340-959E-A7E6CE5D70F0}", "@ConstKeywordAchievementName",
        AchievementDescription = "@ConstKeywordAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ConstKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
            {
                if ((fieldDeclaration.Modifier & Modifiers.Const) == Modifiers.Const)
                {
                    UnlockWith(fieldDeclaration);
                }

                return base.VisitFieldDeclaration(fieldDeclaration, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if ((localVariableDeclaration.Modifier & Modifiers.Const) == Modifiers.Const)
                {
                    UnlockWith(localVariableDeclaration);
                }
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}