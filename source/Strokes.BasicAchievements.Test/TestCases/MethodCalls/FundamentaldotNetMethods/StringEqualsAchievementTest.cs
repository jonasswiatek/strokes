using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(StringEqualsAchievement))]
    public class StringEqualsAchievementTest
    {
        public void bla()
        {
            var bla = string.Equals("str", "str");
        }
    }
}