using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Arrays
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(DeclareMultipleDimArrayAchievement))]
    public class MultiDimArrayTest
    {
        public int[,] multiDimArray;
    }
}