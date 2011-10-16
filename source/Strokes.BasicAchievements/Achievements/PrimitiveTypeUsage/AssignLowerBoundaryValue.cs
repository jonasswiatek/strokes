using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class AssignLowerBoundaryValue<T> : NRefactoryAchievement
        where T : struct
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly string TypeToFind = typeof(T).ToString();
            private readonly List<string> intVariables = new List<string>();

            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                if (variableDeclarationStatement.Type.Is<T>())
                {
                    foreach (var variableDeclaration in variableDeclarationStatement.Variables)
                    {
                        intVariables.Add(variableDeclaration.Name);

                        var memberExpression = variableDeclaration.Initializer as MemberReferenceExpression;
                        if (memberExpression != null)
                        {
                            if (IsMaxValue(memberExpression))
                                UnlockWith(variableDeclarationStatement);
                        }
                    }
                }

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }

            private bool IsMaxValue(MemberReferenceExpression memberExpression)
            {
                if (memberExpression.MemberName.Equals("MinValue"))
                {
                    if (memberExpression.Target is IdentifierExpression)
                    {
                        var ident = (IdentifierExpression)memberExpression.Target;
                        if (TypeToFind.Contains(ident.Identifier))
                            return true;
                    }
                    else if (memberExpression.Target is TypeReferenceExpression)
                    {
                        var typeRef = (TypeReferenceExpression)memberExpression.Target;
                        if (TypeToFind.Contains(typeRef.Type.ToString()))
                            return true;
                    }
                }

                return false;
            }

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                if (assignmentExpression.Left is IdentifierExpression)
                {
                    var identifier = (IdentifierExpression)assignmentExpression.Left;

                    if (intVariables.Contains(identifier.Identifier))
                    {
                        if (assignmentExpression.Right is PrimitiveExpression)
                        {
                            var primitiveExpression = (PrimitiveExpression)assignmentExpression.Right;
                            if (primitiveExpression.Value.Equals("MaxValue"))
                                UnlockWith(assignmentExpression);
                        }
                        else if (assignmentExpression.Right is MemberReferenceExpression)
                        {
                            var memberExpression = (MemberReferenceExpression)assignmentExpression.Right;
                            if (IsMaxValue(memberExpression))
                                UnlockWith(assignmentExpression);
                        }
                    }
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}
