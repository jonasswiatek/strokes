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
    [AchievementDescriptor("{cf9be271-1adb-4d4a-beaa-a5a83c6c9393}", "@StartThreadAchievementName",
        AchievementDescription = "@StartThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class StartThreadAchievement : NRefactoryAchievement
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
                const string typeToUse = "System.Threading.Thread";
                const string methodToFind = "Start";

                if(_codebaseDeclarations.Any(a => a.Name == memberReferenceExpression.Target.GetIdentifier() && a.IsType(typeToUse)) || memberReferenceExpression.IsReferenceOfTypeFromScope(typeToUse))
                {
                    if (memberReferenceExpression.MemberName == methodToFind)
                    {
                        UnlockWith(memberReferenceExpression);
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }
        }
    }

    [AchievementDescriptor("{5dc86ab1-b723-4504-bd97-3473ab3ec149}", "@JoinThreadAchievementName",
        AchievementDescription = "@JoinThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class JoinThreadAchievement : NRefactoryAchievement
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
                const string typeToUse = "System.Threading.Thread";
                const string methodToFind = "Join";

                if (_codebaseDeclarations.Any(a => a.Name == memberReferenceExpression.Target.GetIdentifier() && a.IsType(typeToUse)) || memberReferenceExpression.IsReferenceOfTypeFromScope(typeToUse))
                {
                    if (memberReferenceExpression.MemberName == methodToFind)
                    {
                        UnlockWith(memberReferenceExpression);
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }
        }
    }


    [AchievementDescriptor("{4c5a6472-0a60-46d9-979b-c72746b76b7e}", "@AbortThreadAchievementName",
        AchievementDescription = "@AbortThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class AbortThreadAchievement : NRefactoryAchievement
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
                const string typeToUse = "System.Threading.Thread";
                const string methodToFind = "Abort";

                if (_codebaseDeclarations.Any(a => a.Name == memberReferenceExpression.Target.GetIdentifier() && a.IsType(typeToUse)) || memberReferenceExpression.IsReferenceOfTypeFromScope(typeToUse))
                {
                    if (memberReferenceExpression.MemberName == methodToFind)
                    {
                        UnlockWith(memberReferenceExpression);
                    }
                }

                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }
        }
    }

    [AchievementDescriptor("{B45780D7-0112-403D-9076-3DFB1E462D3C}", "@SleepThreadAchievementName",
        AchievementDescription = "@SleepThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class SleepThreadAchievement : NRefactoryAchievement
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
                const string typeToUse = "System.Threading.Thread";
                const string methodToFind = "Sleep";

                if(memberReferenceExpression.Target.IsCallToType(typeToUse) && memberReferenceExpression.MemberName == methodToFind)
                {
                    UnlockWith(memberReferenceExpression);
                }


                return base.VisitMemberReferenceExpression(memberReferenceExpression, data);
            }
        }
    }
}