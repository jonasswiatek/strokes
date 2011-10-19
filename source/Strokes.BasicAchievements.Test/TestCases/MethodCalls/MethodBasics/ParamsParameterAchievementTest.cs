using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(ParamsParameterAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(EmptyMainAchievement))]
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    public class ParamsParameterAchievementTest
    {
        public void Main(params object[] bla)
        {
        }
    }
}