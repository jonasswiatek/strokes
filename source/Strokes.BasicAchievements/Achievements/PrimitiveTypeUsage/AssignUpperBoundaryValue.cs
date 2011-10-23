using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class AssignUpperBoundaryValue<T> : NRefactoryAchievement
        where T : struct
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                var memberReferenceInitializers = variableDeclarationStatement.Variables.Select(a => a.Initializer).OfType<MemberReferenceExpression>();
                if (memberReferenceInitializers.Any(a => a.IsMemberReferenceOfType<T>() && a.MemberName == "MaxValue"))
                {
                    UnlockWith(variableDeclarationStatement);
                }
                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                var mre = assignmentExpression.Right as MemberReferenceExpression;
                if (mre != null &&
                    assignmentExpression.Operator == AssignmentOperatorType.Assign &&
                    mre.IsMemberReferenceOfType<T>() &&
                    mre.MemberName == "MaxValue")
                {
                    UnlockWith(assignmentExpression);
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}
