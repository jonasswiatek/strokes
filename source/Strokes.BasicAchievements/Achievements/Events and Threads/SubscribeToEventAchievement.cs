using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{635f6af0-73b1-49a0-a671-33d584839834}", "@SubscribeToEventAchievementName",
        AchievementDescription = "@SubscribeToEventAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class SubscribeToEventAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private List<string> eventVars = new List<string>();

            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                if (assignmentExpression.Left is MemberReferenceExpression)
                {
                    MemberReferenceExpression left = (MemberReferenceExpression)assignmentExpression.Left;
                    if (eventVars.Contains(left.MemberName)) // I don't check against correct type yet
                    {
                        if (assignmentExpression.Right is ObjectCreateExpression)
                        {
                            ObjectCreateExpression right = (ObjectCreateExpression)assignmentExpression.Right;
                            if (right.CreateType.Type.Contains("EventHandler") && assignmentExpression.Op == AssignmentOperatorType.Add)
                                UnlockWith(assignmentExpression); // Only works when using the implicit += new SomeEventHandler() syntax
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