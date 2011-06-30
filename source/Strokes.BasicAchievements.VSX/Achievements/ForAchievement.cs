using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("For loop", AchievementDescription = "Use a for loop",
        AchievementCategory = "Basic Achievements")]
    public class ForAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            IEnumerable<BasicAchievement> achievements =
                cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(BasicAchievement.ForLoop);
        }
    }
}