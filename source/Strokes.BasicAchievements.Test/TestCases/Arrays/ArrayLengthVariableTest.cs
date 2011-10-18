using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Arrays
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(DeclareInitArrayAchievement))]
    [ExpectUnlock(typeof(ArrayLengthPropertyAchievement))]
    public class ArrayLengthVariableTest
    {
        public void bla()
        {
            var arr = new[] {1, 2, 3, 4, 5};
            var len = arr.Length;
        }
    }
}