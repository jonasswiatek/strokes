using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
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