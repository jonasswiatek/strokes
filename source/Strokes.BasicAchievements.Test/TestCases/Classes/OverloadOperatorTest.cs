using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(OverloadOperatorAchievement))]
    public class OverloadOperatorTest
    {
        public static OverloadOperatorTest operator +(OverloadOperatorTest c1, OverloadOperatorTest c2)
        {
            return new OverloadOperatorTest();
        }
    }
}