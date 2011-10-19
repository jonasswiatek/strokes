using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(CreateMethodReturnVoidAchievement))]
    public class CreateMethodReturnVoidAchievementTest
    {
        public void Method()
        {
            var bla = "";
        }
    }
}