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
    [AchievementDescriptor("{B3049AD8-51B0-40D9-A01F-DA7DDBF868BF}", "@InlineCommentAchievementName",
        AchievementDescription = "@InlineCommentAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class InlineCommentAchievement : AchievementBase
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
