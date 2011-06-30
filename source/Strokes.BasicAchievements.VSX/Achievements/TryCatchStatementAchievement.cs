using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Try-Catch Statement", AchievementDescription = "Use a try-catch statement",
        AchievementCategory = "Basic Achievements")]
    public class TryCatchStatementAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            IEnumerable<BasicAchievement> achievements =
                cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(BasicAchievement.TryCatchStatement);
        }
    }
}