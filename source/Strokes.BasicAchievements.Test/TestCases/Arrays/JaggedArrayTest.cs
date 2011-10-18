using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Arrays
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(JaggedArrayAchievement))]
    public class JaggedArrayTest
    {
        public int[][] jaggedArray;
    }
}