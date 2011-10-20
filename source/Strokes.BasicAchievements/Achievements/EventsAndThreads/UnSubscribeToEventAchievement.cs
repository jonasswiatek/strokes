using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{cc7889a1-3669-4def-a004-14af540faa98}", "@UnSubscribeToEventAchievementName",
        AchievementDescription = "@UnSubscribeToEventAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class UnSubscribeToEventAchievement : NRefactoryAchievement
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

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                
                var ns = assignmentExpression.GetCurrentNamespace();
                var variable = assignmentExpression.Left.GetIdentifier();
                var fullVariableName = ns + "." + variable;

                if (_codebaseDeclarations.Any(a => a.FullName == fullVariableName && a.DeclarationClassType == TypeDeclarationKind.Event) && assignmentExpression.Operator == AssignmentOperatorType.Subtract)
                {
                    UnlockWith(assignmentExpression);
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}