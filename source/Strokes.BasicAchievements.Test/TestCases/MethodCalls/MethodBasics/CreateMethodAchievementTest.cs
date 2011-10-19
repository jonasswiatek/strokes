using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(CreateMethodAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    public class CreateMethodAchievementTest
    {
        public void Method()
        {
        }
    }
}