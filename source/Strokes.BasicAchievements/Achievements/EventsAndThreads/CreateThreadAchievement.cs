using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{600e9b5d-ef04-46d9-90db-3b0395c7c9a0}", "@CreateThreadAchievementName",
        AchievementDescription = "@CreateThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class CreateThreadAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                foreach(var variable in variableDeclarationStatement.Variables)
                {
                    var objectCreation = variable.Initializer as ObjectCreateExpression;
                    if(objectCreation != null)
                    {
                        var simpleType = objectCreation.Type as SimpleType;
                        if(simpleType != null && simpleType.Identifier == "Thread")
                        {
                            UnlockWith(simpleType);
                            break;
                        }

                        var memberType = objectCreation.Type as MemberType;
                        var fullNamespace = memberType.GetFullName();
                        if(fullNamespace == "System.Threading.Thread")
                        {
                            UnlockWith(memberType);
                        }
                    }
                }
                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}