using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Arrays
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(ArrayLengthPropertyAchievement))]
    public class ArrayLengthFieldTest
    {
        int[] array = new int[0];
        public void bla()
        {
            var len = array.Length;
        }
    }
}