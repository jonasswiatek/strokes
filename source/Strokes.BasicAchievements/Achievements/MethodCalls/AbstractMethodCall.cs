using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class AbstractMethodCall : NRefactoryAchievement
    {
        private readonly string methodName;

        protected AbstractMethodCall()
        {
            this.RequiredOverloads = new List<TypeAndValueRequirementSet>();
        }

        protected AbstractMethodCall(string methodName)
            : this()
        {
            this.methodName = methodName;
        }

        protected List<TypeAndValueRequirementSet> RequiredOverloads
        {
            get;
            set;
        }

        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor()
            {
                MethodToFind = methodName,
                Requirements = RequiredOverloads
            };
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public string MethodToFind
            {
                get;
                set;
            }

            public List<TypeAndValueRequirementSet> Requirements
            {
                get;
                set;
            }

            public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
            {
                //REFACTOR: invocationExpression.Target changed from invocationExpression.TargetObject - no idea if this is correct. Please verify.
                var memberReferenceExpression = invocationExpression.Target as MemberReferenceExpression;
                if (memberReferenceExpression != null)
                {
                    var methodName = memberReferenceExpression.GetCallChainAsString();

                    if (MethodToFind == methodName)
                    {
                        if (Requirements.Count > 0)
                        {
                            foreach (var reqSet in Requirements)
                            {
                                if (!reqSet.Repeating && invocationExpression.Arguments.Count != reqSet.Requirements.Count)
                                {
                                    continue;
                                }

                                int i = 0;
                                foreach (var requirement in reqSet.Requirements)
                                {
                                    if (invocationExpression.Arguments.Count - 1 < i)
                                    {
                                        break;
                                    }

                                    var primitiveArgumentExpression = invocationExpression.Arguments.ElementAt(i) as PrimitiveExpression;
                                    if (primitiveArgumentExpression == null)
                                    {
                                        break;
                                    }

                                    var valueType = primitiveArgumentExpression.Value.GetType();
                                    if (valueType == requirement.Type || valueType.IsSubclassOf(requirement.Type))
                                    {
                                        if (requirement.Type == typeof(string) && requirement.Regex != null)
                                        {
                                            var regex = new Regex(requirement.Regex, requirement.RegexOptions);
                                            var match = regex.IsMatch(primitiveArgumentExpression.Value.ToString());
                                            if (match == false)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    if (i++ == reqSet.Requirements.Count - 1)
                                    {
                                        UnlockWith(invocationExpression);
                                    }
                                }
                            }
                        }
                        else
                        {
                            UnlockWith(invocationExpression);
                        }
                    }
                }

                return base.VisitInvocationExpression(invocationExpression, data);
            }
        }

        protected class TypeAndValueRequirementSet
        {
            public TypeAndValueRequirementSet()
            {
                Requirements = new List<TypeAndValueRequirement>();
            }

            public List<TypeAndValueRequirement> Requirements
            {
                get;
                set;
            }

            public bool Repeating
            {
                get;
                set;
            }
        }

        protected class TypeAndValueRequirement
        {
            public TypeAndValueRequirement()
            {
                RegexOptions = RegexOptions.None;
            }

            public Type Type
            {
                get;
                set;
            }

            public string Regex
            {
                get;
                set;
            }

            public RegexOptions RegexOptions
            {
                get;
                set;
            }
        }
    }
}