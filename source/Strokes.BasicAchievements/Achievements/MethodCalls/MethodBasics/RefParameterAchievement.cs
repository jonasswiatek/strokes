using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{FD2A318D-ECDD-42DD-897F-F2E22E45F2A2}", "@RefParameterAchievementName",
        AchievementDescription = "@RefParameterAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-US/library/14akc2c7(v=VS.100).aspx",
        AchievementCategory = "@Method",
        DependsOn = new[]
        {
            "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
        })]
    public class RefParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data)
            {
                if (parameterDeclaration.ParameterModifier == ParameterModifier.Ref)
                {
                    UnlockWith(parameterDeclaration);
                }

                return base.VisitParameterDeclaration(parameterDeclaration, data);
            }
        }
    }
}