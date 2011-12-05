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
    public abstract class AbstractSystemTypeUsage : NRefactoryAchievement
    {
        private readonly Type systemType;
        private readonly string methodName;

        protected AbstractSystemTypeUsage(Type systemType, string methodName)
        {
            this.systemType = systemType;
            this.methodName = methodName;
        }

        protected virtual bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return true;
        }

        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor(NRefactoryContext, VerifyArgumentUsage, systemType, methodName);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly NRefactoryContext nrefactoryContext;
            private readonly Func<InvocationExpression, bool> verifier;
            private readonly Type systemType;
            private readonly string methodName;

            public Visitor(NRefactoryContext nrefactoryContext, Func<InvocationExpression, bool> verifier, Type systemType, string methodName)
            {
                this.nrefactoryContext = nrefactoryContext;
                this.verifier = verifier;
                this.systemType = systemType;
                this.methodName = methodName;
            }

            public override void OnParsingCompleted()
            {
                var invocation = nrefactoryContext.InvokedSystemTypes.SingleOrDefault
                (
                    a => a.SystemType == systemType && a.MethodName == methodName
                );

                if (invocation != null)
                {
                    var invocationExpressions = new List<InvocationExpression>() { invocation.OriginalExpression };
                    invocationExpressions.AddRange(invocation.Variations);

                    foreach (var invocationVariation in invocationExpressions)
                    {
                        if (verifier(invocationVariation))
                        {
                            UnlockWith(invocationVariation);
                            return;
                        }
                    }
                }
            }
        }
    }
}