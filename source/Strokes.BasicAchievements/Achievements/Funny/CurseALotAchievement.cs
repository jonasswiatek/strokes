using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{284CC74E-F51C-4B33-8A10-5583AE8FE232}", "@CurseAlotAchievementName",
        AchievementDescription = "@CurseAlotAchievementDescription",
        AchievementCategory = "@Funny")]
    public class CurseAlotAchievement : NRefactoryAchievement
    {
        private static int cursecount = 0;
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data)
            {
                string[] foulwords= new string[]
                {
                    "fuck", "shit", "crap", "bollocks" 
                };//if anyone wants to go nuts: feel free to add more :)

                foreach (var foulword in foulwords)
                {
                    if (System.Text.RegularExpressions.Regex.Matches(variableDeclaration.Name, foulword).Count > 0)
                        cursecount++;
                }
                

                if (cursecount>5)
                    UnlockWith(variableDeclaration);

                return base.VisitVariableDeclaration(variableDeclaration, data);
            }
        }
    }
}