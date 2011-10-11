using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{CC0BA7AC-444E-4888-8631-864DF7D404B8}", "@ForEachWithEnumAchievementName",
        AchievementDescription = "@ForEachWithEnumAchievementDescription",
        AchievementCategory = "@ProgramFlow",
    DependsOn = new[]{"{1B9C1201-E2A9-4FE6-A8A6-44ABE06517FD}","{F328611E-562D-4D8B-B1AE-48830DB00C7E}"})]
    
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