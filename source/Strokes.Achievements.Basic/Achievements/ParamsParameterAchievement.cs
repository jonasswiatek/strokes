using System.Linq;
using Strokes.Achievements.Basic.CocoR;
using Strokes.Core;

namespace Strokes.Achievements.Basic.Achievements
{
    [AchievementDescription("Params Parameter", AchievementDescription = "Write a method that uses the params keyword in it's arguments", AchievementCategory = "Basic Achievements")]
    public class ParamsParameterAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);
            
            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.ParamsParameter);
        }
    }
}