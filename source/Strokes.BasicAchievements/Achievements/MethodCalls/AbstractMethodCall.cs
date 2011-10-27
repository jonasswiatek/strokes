using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class AbstractMethodCall : NRefactoryAchievement
    {
        private readonly string _fullMethodName;

        protected AbstractMethodCall()
        {
            RequiredOverloads = new List<TypeAndValueRequirementSet>();
        }

        protected AbstractMethodCall(string fullMethodName) : this()
        {
            _fullMethodName = fullMethodName;
        }

        protected List<TypeAndValueRequirementSet> RequiredOverloads
        {
            get;
            set;
        }

        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            var seperator = _fullMethodName.LastIndexOf(".");
            var typeToUse = _fullMethodName.Substring(0, seperator);
            var methodName = _fullMethodName.Substring(seperator + 1);

            return new Visitor(NRefactoryContext.CodebaseDeclarations, typeToUse, methodName, RequiredOverloads);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly IEnumerable<DeclarationInfo> _codebaseDeclarations;
            private readonly string _systemType;
            private readonly string _methodName;
            private readonly List<TypeAndValueRequirementSet> _requrements;

            public Visitor(IEnumerable<DeclarationInfo> codebaseDeclarations, string systemType, string methodName, List<TypeAndValueRequirementSet> requrements)
            {
                _codebaseDeclarations = codebaseDeclarations;
                _systemType = systemType;
                _methodName = methodName;
                _requrements = requrements;
            }

            public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
            {
                var target = invocationExpression.Target as MemberReferenceExpression;
                if (target != null && target.MemberName == _methodName)
                {
                    var targetSystemType = target.Target.ToString();
                    if(targetSystemType == "string")
                    {
                        targetSystemType = "String"; //Special case. Just elevate a call to string. to String.
                    }

                    if (!targetSystemType.StartsWith("System."))
                    {
                        targetSystemType = "System." + targetSystemType;
                    }
                    if (targetSystemType == _systemType)
                    {
                        if(!_requrements.Any())
                        {
                            UnlockWith(invocationExpression);
                        }
                        else
                        {
                            foreach (var reqSet in _requrements)
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
                                    if (requirement.Type != null)
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