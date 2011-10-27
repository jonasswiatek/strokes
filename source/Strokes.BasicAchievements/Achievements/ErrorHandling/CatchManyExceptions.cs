using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{504D9E72-098E-4E81-A87A-BA198C714EDA}", "@CatchManyExceptionsAchievementName",
        AchievementDescription = "@CatchManyExceptionsAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/0yd65esw(v=VS.100).aspx",
        AchievementCategory = "@ErrorHandling")]
    public class CatchManyExceptionsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
            {
                if (tryCatchStatement.CatchClauses.Count > 5)
                {
                    UnlockWith(tryCatchStatement);
                }
                return base.VisitTryCatchStatement(tryCatchStatement, data);
            }
        }
    }
}