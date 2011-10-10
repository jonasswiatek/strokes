using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{893F52B1-0CC1-49E4-AF44-A856334BA63E}", "@OverloadOperatorAchievementName",
        AchievementDescription = "@OverloadOperatorAchievementDescription",
        AchievementCategory = "@Class")]
    public class OverloadOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data)
            {
                UnlockWith(operatorDeclaration);
                return base.VisitOperatorDeclaration(operatorDeclaration, data);
            }
        }
    }
}