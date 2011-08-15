using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Enumerate an enumeration", AchievementDescription = "Use a foreach loop to enumerate over all elements of ...an enumeration.",
        AchievementCategory = "Program flow")]
    public class ForEachWithEnumAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitForeachStatement(ForeachStatement foreachStatement, object data)
            {
                //Looks convoluted solution not sure this is correct way to detect something of form (foreach(var t in Enum.GetValue/GetNames(...))
                InvocationExpression expr = foreachStatement.Expression as InvocationExpression;

                if (expr != null)
                {
                    MemberReferenceExpression expr2 = expr.TargetObject as MemberReferenceExpression;
                    if (expr2 != null)
                    {
                        IdentifierExpression expr3 = expr2.TargetObject as IdentifierExpression;
                        if (expr3 != null && expr3.Identifier == "Enum")
                        {
                            UnlockWith(foreachStatement);
                        }
                    }
                }
                return base.VisitForeachStatement(foreachStatement, data);
            }

        }
    }
}