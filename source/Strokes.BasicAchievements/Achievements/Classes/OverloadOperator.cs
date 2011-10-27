using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{893F52B1-0CC1-49E4-AF44-A856334BA63E}", "@OverloadOperatorAchievementName",
        AchievementDescription = "@OverloadOperatorAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/aa288467(v=vs.71).aspx",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                })]
    public class OverloadOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data)
            {
                UnlockWith(operatorDeclaration);
                return base.VisitOperatorDeclaration(operatorDeclaration, data);
            }
        }
    }
}