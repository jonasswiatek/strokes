using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{E2B9DA88-438D-403D-985F-8D2B8A522E9D}", "@ParamsParameterAchievementName",
        AchievementDescription = "@ParamsParameterAchievementDescription",
        AchievementCategory = "@Method",
        DependsOn = new[]
        {
            "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
        })]
    public class ParamsParameterAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data)
            {
                if (parameterDeclaration.ParameterModifier == ParameterModifier.Params)
                {
                    UnlockWith(parameterDeclaration);
                }

                return base.VisitParameterDeclaration(parameterDeclaration, data);
            }
        }
    }
}