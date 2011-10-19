using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(StringCompareAchievement))]
    public class StringCompareAchievementTest
    {
        public void bla()
        {
            var bla = System.String.Compare("", "");
        }
    }
}