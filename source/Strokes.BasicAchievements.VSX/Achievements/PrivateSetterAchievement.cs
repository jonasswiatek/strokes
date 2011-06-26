using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Private Setter",
        AchievementDescription = "Write a property of any type with a private setter",
        AchievementCategory = "Basic Achievements")]
    public class PrivateSetterAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            IEnumerable<Parser.BasicAchievement> achievements =
                cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.PrivateSetter);
        }
    }
}