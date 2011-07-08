using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Anonymous Object", AchievementDescription = "Create an anonymous object", AchievementCategory = "Basic Achievements",
        ImageUri = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/AnonObject.png")]
    public class AnonymousObjectAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data)
            {
                var objectCreateExpression = variableDeclaration.Initializer as ObjectCreateExpression;
                if (objectCreateExpression != null && objectCreateExpression.IsAnonymousType)
                {
                    UnlockWith(variableDeclaration);
                }

                return base.VisitVariableDeclaration(variableDeclaration, data);
            }
        }
    }
}