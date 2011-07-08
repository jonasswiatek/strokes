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
    [AchievementDescription("Block comment", AchievementDescription = "Write a block comment", AchievementCategory = "Basic Achievements",
        ImageUri = "/Strokes.BasicAchievements.VSX;component/Achievements/Icons/Basic/BlockComment.png")]
    public class BlockCommentAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();

            var unlocked = false;
            foreach (var file in detectionSession.BuildInformation.ChangedFiles)
            {
                var parser = nRefactorySession.GetParser(file);
                parser.Parse();
                var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();

                unlocked = specials.OfType<Comment>().Any(a => a.CommentType == CommentType.Block);

                if (unlocked)
                    break;
            }

            return unlocked;
        }
    }
}
