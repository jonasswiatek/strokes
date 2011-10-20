using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{8A5F199C-B171-42D4-A12E-69BFB8A9F547}", "@OutParameterAchievementName",
        AchievementDescription = "@OutParameterAchievementDescription",
        AchievementCategory = "@Method",
        DependsOn = new[]
                {
                    "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
                })]
       
    public class OutParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data)
            {
                if (parameterDeclaration.ParameterModifier == ParameterModifier.Out)
                {
                    UnlockWith(parameterDeclaration);
                }

                return base.VisitParameterDeclaration(parameterDeclaration, data);
            }
        }
    }
}