using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{1D2171F4-9D57-4EA7-8B61-C493FC1F8DFC}", "@TooManyDimensionArrayDeclarationAchievementName",
        AchievementDescription = "@TooManyDimensionArrayDeclarationAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
        {
            "{579E6C20-29FE-4D54-A2F0-4D80DAD93F8E}"
        })]
    public class TooManyDimensionArrayDeclarationAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitArraySpecifier(ArraySpecifier arraySpecifier, object data)
            {
                if (arraySpecifier.Dimensions >= 10)
                {
                    UnlockWith(arraySpecifier);
                }

                return base.VisitArraySpecifier(arraySpecifier, data);
            }

            public override object VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, object data)
            {
                if (arrayCreateExpression.Arguments.Count >= 10)
                {
                    UnlockWith(arrayCreateExpression);
                }

                return base.VisitArrayCreateExpression(arrayCreateExpression, data);
            }
        }
    }
}