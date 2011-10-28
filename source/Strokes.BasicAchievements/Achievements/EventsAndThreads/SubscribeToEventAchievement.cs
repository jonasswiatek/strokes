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
    [AchievementDescriptor("{635f6af0-73b1-49a0-a671-33d584839834}", "@SubscribeToEventAchievementName",
        AchievementDescription = "@SubscribeToEventAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/ms366768.aspx",
        AchievementCategory = "@EventsThreads")]
    public class SubscribeToEventAchievement : NRefactoryAchievement
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

                if(_codebaseDeclarations.Any(a => a.FullName == fullVariableName && a.DeclarationClassType == TypeDeclarationKind.Event) && assignmentExpression.Operator == AssignmentOperatorType.Add)
                {
                    UnlockWith(assignmentExpression);
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }
        }
    }
}