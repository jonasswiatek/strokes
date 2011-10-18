using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(ConstKeywordAchievement))]
    public class ConstKeywordVariableTest
    {
        public void Main()
        {
            const string someString = "";
        }
    }
}