using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{

    public abstract class AssignUpperBoundaryValue<T> : NRefactoryAchievement
    {

            protected override AbstractAchievementVisitor CreateVisitor()
            {
                return new Visitor();
            }

            private class Visitor : AbstractAchievementVisitor
            {

                private string TypeToFind = typeof (T).ToString();
                private readonly List<string> _intvariables = new List<string>();



                public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration,
                                                                     object data)
                {

                    if (localVariableDeclaration.TypeReference.Type.Contains(TypeToFind))
                    {
                        foreach (VariableDeclaration variableDeclaration in localVariableDeclaration.Variables)
                        {
                            _intvariables.Add(variableDeclaration.Name);

                            if (variableDeclaration.Initializer is MemberReferenceExpression)
                            {
                                MemberReferenceExpression memb =
                                    (MemberReferenceExpression) variableDeclaration.Initializer;
                                if (IsMaxValue(memb))
                                    UnlockWith(localVariableDeclaration);
                            }
                        }
                    }
                    return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
                }

                private bool IsMaxValue(MemberReferenceExpression memb)
                {
                    if (memb.MemberName.Equals("MaxValue"))
                    {
                        if (memb.TargetObject is IdentifierExpression)
                        {
                            IdentifierExpression ident = (IdentifierExpression) memb.TargetObject;
                            if (TypeToFind.Contains(ident.Identifier))
                                return true;
                        }
                        else if (memb.TargetObject is TypeReferenceExpression)
                        {
                            TypeReferenceExpression typeref = (TypeReferenceExpression)memb.TargetObject;
                            if(TypeToFind.Contains(typeref.TypeReference.ToString()))
                                return true;
                        }
                    }
                    
                    return false;
                }

                public override object VisitAssignmentExpression(
                    ICSharpCode.NRefactory.Ast.AssignmentExpression assignmentExpression, object data)
                {

                    if (assignmentExpression.Left is IdentifierExpression)
                    {
                        IdentifierExpression idexpr = (IdentifierExpression) assignmentExpression.Left;
                        if (_intvariables.Contains(idexpr.Identifier))
                        {
                            if (assignmentExpression.Right is PrimitiveExpression)
                            {
                                PrimitiveExpression prim = (PrimitiveExpression) assignmentExpression.Right;
                                if (prim.Value.Equals("MaxValue"))
                                    UnlockWith(assignmentExpression);
                            }
                            else if (assignmentExpression.Right is MemberReferenceExpression)
                            {
                                MemberReferenceExpression memb = (MemberReferenceExpression) assignmentExpression.Right;
                                if (IsMaxValue(memb))
                                    UnlockWith(assignmentExpression);
                            }
                        }
                    }
                    return base.VisitAssignmentExpression(assignmentExpression, data);
                }

            }
        
    }


}
