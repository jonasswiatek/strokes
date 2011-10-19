using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(CreateSingleLineMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnStringAchievement))]
    public class CreateSingleLineMethodAchievementTest
    {
        public string Method()
        {
            return "";
        }
    }
}