using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Create a constant", AchievementDescription = "Use the const keyword", AchievementCategory = "Basic Achievements")]
    public class ConstKeywordAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>(); //Gets a cached BasicCocoRDetector instance.
            var parser = cocoRDetector.GetParser(detectionSession.BuildInformation.ActiveFile); //Gets a parser for the document.

            return parser.Graph.DeclaredConstants.Any();
        }
    }
}