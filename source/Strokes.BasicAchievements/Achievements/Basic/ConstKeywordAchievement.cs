using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{07D39703-8F4A-4340-959E-A7E6CE5D70F0}", "@ConstKeywordAchievementName",
        AchievementDescription = "@ConstKeywordAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/e6w8fe1b(v=vs.71).aspx",
        AchievementCategory = "@Fundamentals")]
    public class ConstKeywordAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
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