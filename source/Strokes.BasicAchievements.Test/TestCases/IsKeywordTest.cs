using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(UseIsKeywordAchievement))]
    public class IsKeywordTest
    {
        public void Main()
        {
            var s = "";
            var b = s is string;
        }
    }
}