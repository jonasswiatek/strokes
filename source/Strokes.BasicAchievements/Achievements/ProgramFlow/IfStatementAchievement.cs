using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{299F7258-CFB2-4FAE-B5A2-949E1B8AB53B}", "@IfStatementAchievementName",
        AchievementDescription = "@IfStatementAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class IfStatementAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitIfElseStatement(IfElseStatement ifElseStatement, object data)
            {
                UnlockWith(ifElseStatement);

                return base.VisitIfElseStatement(ifElseStatement, data);
            } 
        }
    }
}