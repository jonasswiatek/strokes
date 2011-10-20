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
    [AchievementDescriptor("{EC805EF5-BAB8-43DB-B014-6A1ED350A9B9}", "@DeclareHexShorthandCharAchievementName",
        AchievementDescription = "@DeclareHexShorthandCharAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareHexShorthandCharAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, object data)
            {
                if(primitiveExpression.LiteralValue.StartsWith("'\\x"))
                {
                    UnlockWith(primitiveExpression);
                }
                return base.VisitPrimitiveExpression(primitiveExpression, data);
            }
        }
    }
}
