using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@OverloadOperatorAchievementName",
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