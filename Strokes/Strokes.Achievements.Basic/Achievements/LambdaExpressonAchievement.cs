using System.Linq;
using CSharpAchiever.Achievements.Basic.CocoR;
using CSharpAchiever.Core;

namespace CSharpAchiever.Achievements.Basic.Achievements
{
    [AchievementDescription("Lambda Expression", AchievementDescription = "Use a lambda expression", AchievementCategory = "Basic Achievements")]
    public class LambdaExpressonAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>();
            var achievements = cocoRDetector.DetectAchievements(detectionSession.BuildInformation.ActiveFile);
            
            return achievements.Contains(CocoR.Grammars.Parser.BasicAchievement.LambdaExpression);
        }
    }
}