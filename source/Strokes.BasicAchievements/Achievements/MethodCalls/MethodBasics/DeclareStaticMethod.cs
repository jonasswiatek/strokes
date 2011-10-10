using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0414EFDB-0865-4E3C-9809-B779EA1F6CCF}", "@CreateStaticMethodAchievementName",
        AchievementDescription = "@CreateStaticMethodAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateStaticMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if(methodDeclaration.Modifier.HasFlag(Modifiers.Static))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}