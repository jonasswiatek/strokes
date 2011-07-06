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
        ImageUri = "pack://application:,,,/Strokes.GUI;component/Icons/Basic/BlockComment.png")]
    public class BlockCommentAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();
            var parser = nRefactorySession.GetParser(detectionSession.BuildInformation.ActiveFile);
            parser.Parse();
            var specials = parser.Lexer.SpecialTracker.RetrieveSpecials();

            return specials.OfType<Comment>().Any(a => a.CommentType == CommentType.Block);
        }
    }
}
