using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{cc7889a1-3669-4def-a004-14af540faa98}", "@UnSubscribeToEventAchievementName",
        AchievementDescription = "@UnSubscribeToEventAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class UnSubscribeToEventAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            List<string> eventVars = new List<string>();

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                if (assignmentExpression.Left is MemberReferenceExpression)
                {
                    var left = (MemberReferenceExpression)assignmentExpression.Left;

                    // I don't check against correct type yet
                    if (eventVars.Contains(left.MemberName))
                    {
                        if (assignmentExpression.Right is ObjectCreateExpression)
                        {
                            ObjectCreateExpression right = (ObjectCreateExpression)assignmentExpression.Right;
                            if (right.CreateType.Type.Contains("EventHandler") &&
                                assignmentExpression.Op == AssignmentOperatorType.Subtract)
                            {
                                // Only works when using the implicit += new SomeEventHandler() syntax
                                UnlockWith(assignmentExpression);
                            }
                        }
                    }
                }

                return base.VisitAssignmentExpression(assignmentExpression, data);
            }

            public override object VisitEventDeclaration(EventDeclaration eventDeclaration, object data)
            {
                eventVars.Add(eventDeclaration.Name);

                return base.VisitEventDeclaration(eventDeclaration, data);
            }
        }
    }
}