using System.Linq;
using Strokes.Achievements.Basic.CocoR;
using Strokes.Core;

namespace Strokes.Achievements.Basic.Achievements
{
    [AchievementDescription("Try-Catch Statement", AchievementDescription = "Use a try-catch statement", AchievementCategory = "Basic Achievements")]
    public class TryCatchStatementAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.TryCatchStatement);
        }
    }
}