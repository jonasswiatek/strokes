using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{fc2721c2-8bc8-4638-b696-66b4688df064}", "@ThrownNotImplementedAchievementName",
        AchievementDescription = "@ThrownNotImplementedAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.notimplementedexception.aspx",
        AchievementCategory = "@ErrorHandling")]
    public class ThrownNotImplementedAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitThrowStatement(ThrowStatement throwStatement, object data)
            {
                if (throwStatement.Expression is ObjectCreateExpression)
                {
                    var expr = (ObjectCreateExpression)throwStatement.Expression;
                    var typeRef = expr.Type as SimpleType;

                    if (typeRef != null && typeRef.Identifier == "NotImplementedException")
                    {
                        UnlockWith(throwStatement.Expression);
                    }
                }
                return base.VisitThrowStatement(throwStatement, data);
            }
        }
    }
}