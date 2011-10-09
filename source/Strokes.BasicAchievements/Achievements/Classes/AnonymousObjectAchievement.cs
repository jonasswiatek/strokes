using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{59AD4199-D634-485A-8007-18B3317EFF83}", "@AnonymousObjectAchievementName",
        AchievementDescription = "@AnonymousObjectAchievementDescription",
        AchievementCategory = "@Class",
        Image = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/AnonObject.png")]
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