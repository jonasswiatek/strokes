using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{EAF46E2B-4488-47E8-A362-5F1575676FC6}", "@TooManyModifiersMethodDeclarationAchievementName",
        AchievementDescription = "@TooManyModifiersMethodDeclarationAchievementDescription",
        AchievementCategory = "@Funny")]
    public class TooManyModifiersMethodDeclarationAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                string modifiers= methodDeclaration.Modifier.ToString();

                //A silly little trick to prevent having to count each modifier independently
                if(System.Text.RegularExpressions.Regex.Matches(modifiers,",").Count > 2)
                    UnlockWith(methodDeclaration);
                
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}