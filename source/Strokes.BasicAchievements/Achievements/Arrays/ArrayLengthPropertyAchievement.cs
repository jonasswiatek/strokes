using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5794C0EE-36BB-4F7C-B5A0-1B7887B67F2A}", "@ArrayLengthPropertyAchievementName",
        AchievementDescription = "@ArrayLengthPropertyAchievementDescription",
        AchievementCategory = "@Arrays",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.array.length.aspx",
        DependsOn = new[]
                        {
                            "{B012CA29-340C-47D0-8D39-E2F83FB59D1A}"
                        })]
    public class ArrayLengthPropertyAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor(NRefactoryContext.CodebaseDeclarations);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly IEnumerable<DeclarationInfo> _codebaseDeclarations;

            public Visitor(IEnumerable<DeclarationInfo> codebaseDeclarations)
            {
                _codebaseDeclarations = codebaseDeclarations;
            }

            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if(memberReferenceExpression.MemberName == "Length")
                {
                    var variableName = memberReferenceExpression.Target.GetIdentifier();
                    if(memberReferenceExpression.GetVariablesOfInitializer<ArrayCreateExpression>().Any(a => a.Name == variableName))
                    {
                        UnlockWith(memberReferenceExpression);
                    }
                    else if(_codebaseDeclarations.Any(a => a.Name == variableName && a.Initializer is ArrayCreateExpression))
                    {
                        UnlockWith(memberReferenceExpression);
                    }
                }
                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }
        }
    }
}