using System.Linq;
using CSharpAchiever.Achievements.Basic.CocoR;
using CSharpAchiever.Core;

namespace CSharpAchiever.Achievements.Basic.Achievements
{
    [AchievementDescription("While loop", AchievementDescription = "Use a while loop", AchievementCategory = "Basic Achievements")]
    public class WhileLoopAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);
            
            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.WhileLoop);
        }
    }
}