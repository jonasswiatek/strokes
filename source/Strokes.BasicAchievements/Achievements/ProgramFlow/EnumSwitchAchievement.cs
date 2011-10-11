using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
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
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            readonly List<string> _enumMembers = new List<string>();
            readonly Dictionary<string, SwitchStatement> _switchLabelMembers = new Dictionary<string, SwitchStatement>();
            
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if(typeDeclaration.Type == ClassType.Enum)
                {
                    _enumMembers.Add(typeDeclaration.Name);
                }

                var intersectingSwitchStatement = GetIntersection();
                if (intersectingSwitchStatement != null)
                {
                    UnlockWith(intersectingSwitchStatement);
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }

            public override object VisitSwitchStatement(SwitchStatement switchStatement, object data)
            {
                foreach(var secton in switchStatement.SwitchSections)
                {
                    foreach(var label in secton.SwitchLabels)
                    {
                        var memberRef = label.Label as MemberReferenceExpression;
                        var targetObject = memberRef != null ? memberRef.TargetObject as IdentifierExpression : null;
                        if(targetObject != null)
                        {
                            if (!_switchLabelMembers.ContainsKey(targetObject.Identifier))
                            {
                                _switchLabelMembers.Add(targetObject.Identifier, switchStatement);
                            }
                        }
                    }
                }

                var intersectingSwitchStatement = GetIntersection();
                if (intersectingSwitchStatement != null)
                {
                    UnlockWith(intersectingSwitchStatement);
                }

                return base.VisitSwitchStatement(switchStatement, data);
            }

            private SwitchStatement GetIntersection()
            {
                var intersection = _enumMembers.Intersect(_switchLabelMembers.Keys);
                if(intersection.Any())
                {
                    var sw = _switchLabelMembers[intersection.First()];
                    return sw;
                }
                return null;
            }
        }
    }
}