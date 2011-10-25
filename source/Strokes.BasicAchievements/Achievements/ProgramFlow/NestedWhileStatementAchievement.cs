using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{b9ab2754-2ff6-4892-887b-1501ae9a5289}", "@NestedWhileStatementAchievementName",
        AchievementDescription = "@NestedWhileStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow",
        DependsOn = new[]
        {
            "{E61CFC56-7F74-48B9-A19A-FB414D35CA6B}"
        })]
    public class NestedWhileStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitWhileStatement(WhileStatement whileStatement, object data)
            {

                if(whileStatement.EmbeddedStatement is BlockStatement)
                {
                    foreach (Statement innerstatement in (BlockStatement)whileStatement.EmbeddedStatement)
                    {
                        if(innerstatement is WhileStatement || innerstatement is DoWhileStatement)
                            UnlockWith(whileStatement);
                    }
                }
                return base.VisitWhileStatement(whileStatement, data);
            }

            public override object  VisitDoWhileStatement(DoWhileStatement doWhileStatement, object data)
            {

                if (doWhileStatement.EmbeddedStatement is BlockStatement)
                {
                    foreach (Statement innerstatement in (BlockStatement)doWhileStatement.EmbeddedStatement)
                    {
                        if (innerstatement is WhileStatement || innerstatement is DoWhileStatement)
                            UnlockWith(doWhileStatement);
                    }
                }
                return base.VisitDoWhileStatement(doWhileStatement, data);
            }

           
        }
    }
}