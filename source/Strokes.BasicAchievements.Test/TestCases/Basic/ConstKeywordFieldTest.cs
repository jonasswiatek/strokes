using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(ConstKeywordAchievement))]
    public class ConstKeywordFieldTest
    {
        const string SomeString = "";
    }
}