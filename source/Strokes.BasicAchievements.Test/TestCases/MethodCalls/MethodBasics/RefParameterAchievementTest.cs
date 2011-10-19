using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(RefParameterAchievement))]
    [ExpectUnlock(typeof(CreateMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    public class RefParameterAchievementTest
    {
        public void Method(ref string bla)
        {
            bla = "";
        }
    }
}