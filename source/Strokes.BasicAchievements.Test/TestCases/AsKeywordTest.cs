using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(UseAsKeywordAchievement))]
    public class AsKeywordTest
    {
        public void Main()
        {
            var s = "";
            var b = s as object;
        }
    }
}