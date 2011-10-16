using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class DeclareInitializePrimitiveType<T> : NRefactoryAchievement
        where T : struct
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitVariableInitializer(VariableInitializer variableInitializer, object data)
            {
                var expression = variableInitializer.Initializer as ArrayCreateExpression;

                if (expression != null && expression.Type.Is<T>())
                    if (expression.Type.Is<T>())
                        UnlockWith(variableInitializer);

                return base.VisitVariableInitializer(variableInitializer, data);
            }
        }
    }
}
