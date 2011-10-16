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
            /* REFACTOR: How to do this with NRefactory5
            var nrefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();
            var filename = detectionSession.BuildInformation.ActiveFile;
            var parser = nrefactorySession.GetCompilationUnit(filename);

            var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();

            return specials.OfType<Comment>().Any(a => a.CommentType == CommentType.SingleLine);*/

            return false;
        }
    }
}
