using System;
using System.Linq;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;

namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class SystemTypeInvocationVisitor : DepthFirstAstVisitor<object, object>
    {
        public IList<SystemTypeInvocaton> InvokedSystemTypes { get; private set; }

        public SystemTypeInvocationVisitor()
        {
            InvokedSystemTypes = new List<SystemTypeInvocaton>();
        }

        public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
        {
            var previousInvocaton = InvokedSystemTypes.FirstOrDefault(a => a.OriginalExpression.Target.ToString() == invocationExpression.Target.ToString());
            if(previousInvocaton != null)
            {
                previousInvocaton.Variations.Add(invocationExpression);
                return base.VisitInvocationExpression(invocationExpression, data);
            }

            var targetMember = invocationExpression.Target as MemberReferenceExpression;
            if(targetMember == null)
                return base.VisitInvocationExpression(invocationExpression, data);

            var targetMemberName = targetMember.Target.ToString();
            Type systemType;

            //1st strategy - just try directly. This will work if the type is fully named (like System.Console or System.Threading.Thread)
            if (TryGetType(targetMemberName, out systemType))
            {
                InvokedSystemTypes.Add(new SystemTypeInvocaton()
                                           {
                                               MethodName = targetMember.MemberName,
                                               OriginalExpression = invocationExpression,
                                               SystemType = systemType
                                           });
                return base.VisitInvocationExpression(invocationExpression, data);
            }

            //2nd strategy. Append all usings to the invoked thing.
            foreach(var ns in invocationExpression.GetUsings())
            {
                if(TryGetType(ns + "." + targetMemberName, out systemType))
                {
                    InvokedSystemTypes.Add(new SystemTypeInvocaton()
                    {
                        MethodName = targetMember.MemberName,
                        OriginalExpression = invocationExpression,
                        SystemType = systemType
                    });

                    return base.VisitInvocationExpression(invocationExpression, data);
                }
            }

            //3rd strategy. The expensive one: attempt to find an identifiers type from the scope.
            var current = targetMember.Target.Parent;
            while (current != null)
            {
                var variableDeclarations = current.Descendants.OfType<VariableDeclarationStatement>();
                if (variableDeclarations.Any())
                {
                    foreach (var variableDeclaration in variableDeclarations)
                    {
                        foreach (var variable in variableDeclaration.Variables)
                        {
                            var objectCreation = variable.Initializer as ObjectCreateExpression;
                            if (objectCreation != null)
                            {
                                foreach (var ns in invocationExpression.GetUsings())
                                {
                                    var typeName = objectCreation.Type.ToString();
                                    if (TryGetType(ns + "." + typeName, out systemType))
                                    {
                                        InvokedSystemTypes.Add(new SystemTypeInvocaton()
                                        {
                                            MethodName = targetMember.MemberName,
                                            OriginalExpression = invocationExpression,
                                            SystemType = systemType
                                        });

                                        return base.VisitInvocationExpression(invocationExpression, data);
                                    }
                                }
                            }
                        }
                    }
                }

                current = current.Parent;
            }

            return base.VisitInvocationExpression(invocationExpression, data);
        }

        private bool TryGetType(string typeName, out Type type)
        {
            type = Type.GetType(typeName, false, true);
            return type != null;
        }
    }
}
