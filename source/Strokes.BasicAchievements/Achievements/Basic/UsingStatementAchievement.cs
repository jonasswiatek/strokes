using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{92A3A4FC-DDDF-4C85-A015-F1592C9B658F}", "@UsingStatementAchievementName",
        AchievementDescription = "@UsingStatementAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class UsingStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor  
        {
            public override object VisitUsingStatement(UsingStatement usingStatement, object data)
            {
                UnlockWith(usingStatement);

                return base.VisitUsingStatement(usingStatement, data);
            }
        }
    }
}