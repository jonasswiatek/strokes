using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    public class ArrayTest
    {
        public ArrayTest()
        {
            int[] array = new int[0];
        }
    }
}