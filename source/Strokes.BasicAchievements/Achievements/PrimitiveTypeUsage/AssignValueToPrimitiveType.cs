using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class AssignValueToPrimitiveType<T> : NRefactoryAchievement
        where T : struct
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly string TypeToFind = typeof(T).ToString();

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                var primitiveExpression = assignmentExpression.Right as PrimitiveExpression;
                if (primitiveExpression != null && assignmentExpression.Operator == AssignmentOperatorType.Assign)
                {
                    if (primitiveExpression.Value.GetType().ToString() == TypeToFind)
                    {
                        UnlockWith(assignmentExpression);
                    }
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}
