using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{284CC74E-F51C-4B33-8A10-5583AE8FE232}", "@CurseAlotAchievementName",
        AchievementDescription = "@CurseAlotAchievementDescription",
        HintUrl = "http://en.wikipedia.org/wiki/Tourette",
        AchievementCategory = "@Funny")]
    public class CurseAlotAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private int curseCount = 0; //This is where it should be

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
                            curseCount++;
                    }
                }

                if (curseCount > 5)
                    UnlockWith(variableDeclarationStatement);

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}