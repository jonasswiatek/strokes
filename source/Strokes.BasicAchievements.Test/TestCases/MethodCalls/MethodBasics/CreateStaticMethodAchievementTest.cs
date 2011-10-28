using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(CreateStaticMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    public class CreateStaticMethodAchievementTest
    {
        public static void bla(string someOutParam)
        {
        }
    }
}