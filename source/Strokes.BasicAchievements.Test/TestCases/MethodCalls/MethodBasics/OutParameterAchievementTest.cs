using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(OutParameterAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    public class OutParameterAchievementTest
    {
        public void bla(out string someOutParam)
        {
            someOutParam = "";
        }
    }
}