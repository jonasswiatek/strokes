using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{779C753E-CBD6-4386-A22A-9A722BB39AA1}", "@SwitchAchievementName",
        AchievementDescription = "@SwitchAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class SwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                UnlockWith(switchStatement);

                return base.VisitSwitchStatement(switchStatement, data);
            }
        }
    }
}