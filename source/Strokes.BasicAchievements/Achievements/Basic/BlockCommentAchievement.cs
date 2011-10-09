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
    [AchievementDescriptor("{ADEDE81C-9350-40AB-882F-30856B2C6E5C}", "@BlockCommentAchievementName",
        AchievementDescription = "@BlockCommentAchievementDescription",
        AchievementCategory = "@Fundamentals",
        Image="/Strokes.BasicAchievements;component/Achievements/Icons/Basic/BlockComment.png")]

    public class BlockCommentAchievement : AchievementBase
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();

            var unlocked = false;
            var parser = nRefactorySession.GetParser(detectionSession.BuildInformation.ActiveFile);
            parser.Parse();
            var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();

            unlocked = specials.OfType<Comment>().Any(a => a.CommentType == CommentType.Block);

            return unlocked;
        }
    }
}
