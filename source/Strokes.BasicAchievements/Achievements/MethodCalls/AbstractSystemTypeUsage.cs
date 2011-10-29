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
        private readonly Type _systemType;
        private readonly string _methodName;

        protected AbstractSystemTypeUsage(Type systemType, string methodName)
        {
            _systemType = systemType;
            _methodName = methodName;
        }

        protected virtual bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return true;
        }

        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor(NRefactoryContext, VerifyArgumentUsage, _systemType, _methodName);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly NRefactoryContext _nrefactoryContext;
            private readonly Func<InvocationExpression, bool> _verifier;
            private readonly Type _systemType;
            private readonly string _methodName;

            public Visitor(NRefactoryContext nrefactoryContext, Func<InvocationExpression, bool> verifier, Type systemType, string methodName)
            {
                _nrefactoryContext = nrefactoryContext;
                _verifier = verifier;
                _systemType = systemType;
                _methodName = methodName;
            }

            public override void OnParsingCompleted()
            {
                if (_systemType == typeof(string))
                {
                    var kk = "";
                }
                var invocation = _nrefactoryContext.InvokedSystemTypes.SingleOrDefault(a => a.SystemType == _systemType && a.MethodName == _methodName);
                if(invocation == null)
                    return;

                var invocationExpressions = new List<InvocationExpression>() {invocation.OriginalExpression};
                invocationExpressions.AddRange(invocation.Variations);

                foreach(var invocationVariation in invocationExpressions)
                {
                    if(_verifier(invocationVariation))
                    {
                        UnlockWith(invocationVariation);
                        return;
                    }
                }
            }
        }
    }
}