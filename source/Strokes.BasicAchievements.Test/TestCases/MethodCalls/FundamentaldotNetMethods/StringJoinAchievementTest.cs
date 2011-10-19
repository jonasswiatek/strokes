using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(StringJoinAchievement))]
    public class StringJoinAchievementTest
    {
        public void bla()
        {
            var bla = System.String.Join(".", "", "", "");
        }
    }
}