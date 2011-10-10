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
            public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
            {
                if(assignmentExpression.Left is MemberReferenceExpression)
                {
                    MemberReferenceExpression left = (MemberReferenceExpression) assignmentExpression.Left;
                    if (eventvars.Contains(left.MemberName)) //I doin't check against correct type yet
                    {
                        if(assignmentExpression.Right is ObjectCreateExpression)
                        {
                            ObjectCreateExpression right = (ObjectCreateExpression) assignmentExpression.Right;
                            if(right.CreateType.Type.Contains("EventHandler") && assignmentExpression.Op== AssignmentOperatorType.Subtract)
                                UnlockWith(assignmentExpression); //Only works when using the implicit += new SomeEventHandler() syntax
                        }
                    }
                    

                }
                return base.VisitAssignmentExpression(assignmentExpression, data);
            }

           
        

        List<string> eventvars= new List<string>();

            public override object VisitEventDeclaration(EventDeclaration eventDeclaration, object data)
            {
                eventvars.Add(eventDeclaration.Name);
                return base.VisitEventDeclaration(eventDeclaration, data);
            }
        }
    }
}