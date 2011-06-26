using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Try-Finally Statement",
        AchievementDescription = "Use the a try-finally without a catch statement.",
        AchievementCategory = "Basic Achievements")]
    public class TryFinallyStatementAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            IEnumerable<Parser.BasicAchievement> achievements =
                cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.TryFinallyStatment);
        }
    }
}