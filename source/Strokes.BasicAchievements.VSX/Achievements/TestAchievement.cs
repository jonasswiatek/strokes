using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Test", AchievementDescription = "Test", AchievementCategory = "Basic Achievements")]
    public class TestAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data)
            {
                ObjectCreateExpression expr = variableDeclaration.Initializer as ObjectCreateExpression;
                if (expr != null)
                    UnlockWith(variableDeclaration);
                
                return base.VisitVariableDeclaration(variableDeclaration, data);
            }
        }
    }
}