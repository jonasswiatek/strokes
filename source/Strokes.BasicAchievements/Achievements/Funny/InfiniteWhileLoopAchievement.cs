using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{19F147D7-63B7-40B2-8863-A8CEF0E162F8}", "@InfiniteWhileLoopAchievementName",
        AchievementDescription = "@InfiniteWhileLoopAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{E61CFC56-7F74-48B9-A19A-FB414D35CA6B}"
        })]
    public class InfiniteWhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitWhileStatement(WhileStatement whileStatement, object data)
            {
                var condition = whileStatement.Condition as PrimitiveExpression;
                if (condition != null && condition.LiteralValue == "true")
                {
                    UnlockWith(whileStatement);
                }
                return base.VisitWhileStatement(whileStatement, data);
            }
        }
    }
}