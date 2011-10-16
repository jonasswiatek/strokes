using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{07D39703-8F4A-4340-959E-A7E6CE5D70F0}", "@ConstKeywordAchievementName",
        AchievementDescription = "@ConstKeywordAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ConstKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
            {
                if ((fieldDeclaration.Modifiers & Modifiers.Const) == Modifiers.Const)
                {
                    UnlockWith(fieldDeclaration);
                }

                return base.VisitFieldDeclaration(fieldDeclaration, data);
            }

            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                if ((variableDeclarationStatement.Modifiers & Modifiers.Const) == Modifiers.Const)
                {
                    UnlockWith(variableDeclarationStatement);
                }

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}