using System.Linq;
using Strokes.Achievements.Basic.CocoR;
using Strokes.Core;

namespace Strokes.Achievements.Basic.Achievements
{
    [AchievementDescription("Foreach loop", AchievementDescription = "Use a foreach loop", AchievementCategory = "Basic Achievements")]
    public class ForEachAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);
            
            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.ForeachLoop);
        }
    }
}