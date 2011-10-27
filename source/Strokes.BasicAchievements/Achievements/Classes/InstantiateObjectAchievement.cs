using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{16E54EE2-BFC4-4350-97F3-F98E92B1C8D3}", "@InstantiateObjectAchievementName",
        AchievementDescription = "@InstantiateObjectAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/x9afc042.aspx",
        AchievementCategory = "@Class")]
    public class InstantiateObjectAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
            {
                UnlockWith(objectCreateExpression);

                return base.VisitObjectCreateExpression(objectCreateExpression, data);
            }
        }
    }
}