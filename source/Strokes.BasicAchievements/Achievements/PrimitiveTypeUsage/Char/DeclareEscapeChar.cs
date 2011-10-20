using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;
using Strokes.BasicAchievements.NRefactory;
using System.Text.RegularExpressions;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5EA1926B-0EF7-4B7A-AAA3-729702F44F97}", "@DeclareEscapeCharAchievementName",
        AchievementDescription = "@DeclareEscapeCharAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareEscapeCharAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, object data)
            {
                if (primitiveExpression.LiteralValue.Contains("\\"))
                {
                    UnlockWith(primitiveExpression);
                }
                return base.VisitPrimitiveExpression(primitiveExpression, data);
            }
        }
    }
}
