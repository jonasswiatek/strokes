using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Create a constant", AchievementDescription = "Use the const keyword", AchievementCategory = "Fundamentals")]
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