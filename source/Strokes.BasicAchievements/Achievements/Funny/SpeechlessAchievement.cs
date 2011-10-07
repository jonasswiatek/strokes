using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{05958BCA-8039-4ABD-A6F8-87573D977E6B}", "@SpeechlessAchievementName",
        AchievementDescription = "@SpeechlessAchievementDescription",
        AchievementCategory = "@Funny")]
    public class SpeechlessAchievement : NRefactoryAchievement
    {
        private static int cursecount = 0;
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data)
            {
                string[] foulwords= new string[]
                {
                    "meh","blah", "pft", "rrrr","blib","blab", "blub","lol","uhu","aaah"
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