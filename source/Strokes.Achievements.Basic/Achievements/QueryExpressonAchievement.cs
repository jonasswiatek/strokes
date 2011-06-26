using System.Linq;
using Strokes.Achievements.Basic.CocoR;
using Strokes.Core;

namespace Strokes.Achievements.Basic.Achievements
{
    [AchievementDescription("Query Expression", AchievementDescription = "Use a query expression", AchievementCategory = "Basic Achievements")]
    public class QueryExpressonAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);
            
            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.QueryExpression);
        }
    }
}