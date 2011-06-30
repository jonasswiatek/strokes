using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Create enumeration", AchievementDescription = "Create an enum type.",
        AchievementCategory = "Basic Achievements")]
    public class EnumInitializerAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(BasicAchievement.EnumInitializer);
        }
    }
}