using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
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
            //Pass typeDeclarations into the constructor
            return new Visitor(CodebaseTypeDeclarations);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly IEnumerable<TypeDeclarationInfo> _typeDeclarationInfos;

            // Get the typeDeclarations from the constructor
            public Visitor(IEnumerable<TypeDeclarationInfo> typeDeclarationInfos)
            {
                _typeDeclarationInfos = typeDeclarationInfos;
            }

            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                foreach (var secton in switchStatement.SwitchSections)
                {
                    foreach (var label in secton.SwitchLabels)
                    {
                        var memberRef = label.Label as MemberReferenceExpression;
                        var targetObject = memberRef != null ? memberRef.TargetObject as IdentifierExpression : null;
                        if (targetObject != null)
                        {
                            if(_typeDeclarationInfos.Any(a => a.TypeName == targetObject.Identifier && a.DetinitionTypeDeclarationKind == TypeDeclarationKind.Enum))
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