using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using ICSharpCode.NRefactory.CSharp;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{05958BCA-8039-4ABD-A6F8-87573D977E6B}", "@SpeechlessAchievementName",
        AchievementDescription = "@SpeechlessAchievementDescription",
        AchievementCategory = "@Funny")]
    public class SpeechlessAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private int _curseCount = 0;
            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                var foulwords = new[]
                {
                    "meh","blah", "pft", "rrrr","blib","blab", "blub","lol","uhu","aaah"
                };

                foreach (var foulword in foulwords)
                {
                    foreach (var variable in variableDeclarationStatement.Variables)
                    {
                        if (Regex.Matches(variable.Name, foulword).Count > 0)
                            _curseCount++;
                    }
                }

                if (_curseCount > 5)
                    UnlockWith(variableDeclarationStatement);

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}