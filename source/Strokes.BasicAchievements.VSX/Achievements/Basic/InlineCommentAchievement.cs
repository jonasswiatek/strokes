using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Inline Commentary", AchievementDescription = "Write an inline comment", AchievementCategory = "Fundamentals")]
    public class InlineCommentAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();

            var unlocked = false;

            var parser = nRefactorySession.GetParser(detectionSession.BuildInformation.ActiveFile);
            parser.Parse();
            var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();

            unlocked = specials.OfType<Comment>().Any(a => a.CommentType == CommentType.SingleLine);


            return unlocked;
        }
    }
}
