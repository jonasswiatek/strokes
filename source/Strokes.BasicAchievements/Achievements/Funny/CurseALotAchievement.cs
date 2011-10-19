using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{284CC74E-F51C-4B33-8A10-5583AE8FE232}", "@CurseAlotAchievementName",
        AchievementDescription = "@CurseAlotAchievementDescription",
        AchievementCategory = "@Funny")]
    public class CurseAlotAchievement : NRefactoryAchievement
    {
        //private static int curseCount = 0; //WHO MADE THIS STATIC (and placed it here)?! WHOEM EVER YOU ARE: ACHIEVEMENT UNLOCKED [MAKE JONAS SPEND 1½ HOUR DEBUGGING :D]
        
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private int _curseCount = 0; //This is where it should be

            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                var foulwords = new[]
                {
                    "fuck", "shit", "crap", "bollocks" 
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