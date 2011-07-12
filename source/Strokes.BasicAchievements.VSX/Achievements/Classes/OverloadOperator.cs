using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Operator overload", AchievementDescription = "Overload an operator", AchievementCategory = "Basic Achievements")]
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