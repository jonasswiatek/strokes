using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Query Expression", AchievementDescription = "Use a query expression",
        AchievementCategory = "Basic Achievements")]
    public class QueryExpressonAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            IEnumerable<BasicAchievement> achievements =
                cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);

            return achievements.Contains(BasicAchievement.QueryExpression);
        }
    }
}