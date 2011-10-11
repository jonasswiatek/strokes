using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    public class ArrayTest
    {
        public void bla()
        {
            int[] array = new int[0];
        }
    }
}