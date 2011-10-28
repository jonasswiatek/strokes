using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{C18FCAA9-454D-4A71-9CD4-19D6508EFF42}", "@DoWhileLoopAchievementName",
        AchievementDescription = "@DoWhileLoopAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/370s1zax(v=VS.100).aspx",
        AchievementCategory = "@ProgramFlow")]
    public class DoWhileLoopAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitDoWhileStatement(ICSharpCode.NRefactory.CSharp.DoWhileStatement doWhileStatement, object data)
            {
                UnlockWith(doWhileStatement);

                return base.VisitDoWhileStatement(doWhileStatement, data);
            }
        }
    }
}