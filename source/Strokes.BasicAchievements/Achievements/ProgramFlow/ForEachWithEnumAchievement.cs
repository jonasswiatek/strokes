using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{CC0BA7AC-444E-4888-8631-864DF7D404B8}", "@ForEachWithEnumAchievementName",
        AchievementDescription = "@ForEachWithEnumAchievementDescription",
        AchievementCategory = "@ProgramFlow"/*,
    DependsOn = new[]{"{1B9C1201-E2A9-4FE6-A8A6-44ABE06517FD}","{F328611E-562D-4D8B-B1AE-48830DB00C7E}"}*/)]
    
    public class ForEachWithEnumAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitForeachStatement(ForeachStatement foreachStatement, object data)
            {
                var invocationExpression = foreachStatement.InExpression as InvocationExpression;
                if(invocationExpression != null && invocationExpression.Target.ToString().EndsWith("Enum.GetValues"))
                {
                    UnlockWith(invocationExpression);
                }

                return base.VisitForeachStatement(foreachStatement, data);
            }
        }
    }
}