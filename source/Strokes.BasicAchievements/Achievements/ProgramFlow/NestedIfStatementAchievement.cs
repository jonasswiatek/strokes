using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{A050D53A-F434-48EB-8A22-3F44F6D5F1DF}", "@NestedIfStatementAchievementName",
        AchievementDescription = "@NestedIfStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow",
        DependsOn = new[]
        {
            "{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}"
        })]
    public class NestedIfStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                if (ifElseStatement.TrueStatement is BlockStatement)
                {
                    foreach (var statement in (ifElseStatement.TrueStatement as BlockStatement).Statements)
                    {
                        if (statement is IfElseStatement)
                            UnlockWith(ifElseStatement);
                    }
                }

                if (ifElseStatement.FalseStatement is BlockStatement)
                {
                    foreach (var statement in (ifElseStatement.FalseStatement as BlockStatement).Statements)
                    {
                        if (statement is IfElseStatement)
                            UnlockWith(ifElseStatement);
                    }
                }

                return base.VisitIfElseStatement(ifElseStatement, data);
            }
        }
    }
}