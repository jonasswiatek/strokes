using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(DeclareInitArrayAchievement))]
    public class ArrayTest
    {
        public void bla()
        {
            int[] array = new int[0];
            var arr = new[] {1, 2, 3, 4, 5};
        }
    }
}