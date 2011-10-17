using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5FAA2B73-5963-48D2-B382-2B46690EC4BF}", "@EnumSwitchAchievementName",
        AchievementDescription = "@EnumSwitchAchievementDescription",
        AchievementCategory = "@ProgramFlow",
        DependsOn = new[]
        {
            "{1B9C1201-E2A9-4FE6-A8A6-44ABE06517FD}"
        })]
    public class EnumSwitchAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor(NRefactoryContext.CodebaseDeclarations);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly IEnumerable<DeclarationInfo> codebaseDeclarationInfos;

            public Visitor(IEnumerable<DeclarationInfo> codebaseDeclarationInfos)
            {
                this.codebaseDeclarationInfos = codebaseDeclarationInfos;
            }

            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                foreach (var section in switchStatement.SwitchSections)
                {
                    foreach (var label in section.CaseLabels)
                    {
                        var memberRef = label.Expression as MemberReferenceExpression;
                        var targetObject = memberRef != null ? memberRef.Target as IdentifierExpression : null;
                        if (targetObject != null)
                        {
                            var hasEnums = codebaseDeclarationInfos.Any(a =>
                                     a.Name == targetObject.Identifier &&
                                     a.DeclarationClassType == TypeDeclarationKind.Enum);

                            if (hasEnums)
                            {
                                UnlockWith(switchStatement);
                                break;
                            }
                        }
                    }
                }

                return base.VisitSwitchStatement(switchStatement, data);
            }
        }
    }
}