using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(StringConcatAchievement))]
    public class StringConcatAchievementTest
    {
        public void bla()
        {
            var bla = System.String.Concat("", "");
        }
    }
}