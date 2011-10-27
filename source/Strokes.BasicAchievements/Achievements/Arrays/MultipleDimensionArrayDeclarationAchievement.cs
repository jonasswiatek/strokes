using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{579E6C20-29FE-4D54-A2F0-4D80DAD93F8E}", "@DeclareMultipleDimArrayAchievementName", 
        AchievementDescription = "@DeclareMultipleDimArrayAchievementDescription",
        AchievementCategory = "@Arrays",
        HintUrl = "http://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx",
        DependsOn = new[]
                        {
                            "{B012CA29-340C-47D0-8D39-E2F83FB59D1A}"
                        })]
    public class DeclareMultipleDimArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitArraySpecifier(ICSharpCode.NRefactory.CSharp.ArraySpecifier arraySpecifier, object data)
            {
                if(arraySpecifier.Dimensions > 1)
                {
                    UnlockWith(arraySpecifier);
                }

                return base.VisitArraySpecifier(arraySpecifier, data);
            }
        }
    }
}