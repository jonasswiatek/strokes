using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{cf9be271-1adb-4d4a-beaa-a5a83c6c9393}", "@StartThreadAchievementName",
        AchievementDescription = "@StartThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class StartThreadAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private List<string> threadVars = new List<string>();

            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if (memberReferenceExpression.MemberName == "Start")
                {
                    if (memberReferenceExpression.TargetObject is IdentifierExpression)
                    {
                        var id = (IdentifierExpression)memberReferenceExpression.TargetObject;
                        if (threadVars.Contains(id.Identifier))
                        {
                            UnlockWith(memberReferenceExpression);
                        }
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type.Equals("Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("Threading.Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("System.Threading.Thread"))
                {
                    foreach (var variableDeclaration in localVariableDeclaration.Variables)
                    {
                        threadVars.Add(variableDeclaration.Name);
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{5dc86ab1-b723-4504-bd97-3473ab3ec149}", "@JoinThreadAchievementName",
        AchievementDescription = "@JoinThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class JoinThreadAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private List<string> threadVars = new List<string>();

            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if (memberReferenceExpression.MemberName == "Join")
                {
                    if (memberReferenceExpression.TargetObject is IdentifierExpression)
                    {
                        var id = (IdentifierExpression)memberReferenceExpression.TargetObject;
                        if (threadVars.Contains(id.Identifier))
                        {
                            UnlockWith(memberReferenceExpression);
                        }
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type.Equals("Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("Threading.Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("System.Threading.Thread"))
                {
                    foreach (VariableDeclaration variableDeclaration in localVariableDeclaration.Variables)
                    {
                        threadVars.Add(variableDeclaration.Name);
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }


    [AchievementDescriptor("{4c5a6472-0a60-46d9-979b-c72746b76b7e}", "@AbortThreadAchievementName",
        AchievementDescription = "@AbortThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class AbortThreadAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private List<string> threadVars = new List<string>();

            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if (memberReferenceExpression.MemberName == "Abort")
                {
                    if (memberReferenceExpression.TargetObject is IdentifierExpression)
                    {
                        var id = (IdentifierExpression)memberReferenceExpression.TargetObject;
                        if (threadVars.Contains(id.Identifier))
                        {
                            UnlockWith(memberReferenceExpression);
                        }
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type.Equals("Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("Threading.Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("System.Threading.Thread"))
                {
                    foreach (VariableDeclaration variableDeclaration in localVariableDeclaration.Variables)
                    {
                        threadVars.Add(variableDeclaration.Name);
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{B45780D7-0112-403D-9076-3DFB1E462D3C}", "@SleepThreadAchievementName",
        AchievementDescription = "@SleepThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class SleepThreadAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private List<string> threadVars = new List<string>();

            public override object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data)
            {
                if (memberReferenceExpression.MemberName == "Sleep")
                {
                    if (memberReferenceExpression.TargetObject is IdentifierExpression)
                    {
                        IdentifierExpression id = (IdentifierExpression)memberReferenceExpression.TargetObject;
                        if (threadVars.Contains(id.Identifier))
                        {
                            UnlockWith(memberReferenceExpression);
                        }
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type.Equals("Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("Threading.Thread") ||
                    localVariableDeclaration.TypeReference.Type.Equals("System.Threading.Thread"))
                {
                    foreach (VariableDeclaration variableDeclaration in localVariableDeclaration.Variables)
                    {
                        threadVars.Add(variableDeclaration.Name);
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}