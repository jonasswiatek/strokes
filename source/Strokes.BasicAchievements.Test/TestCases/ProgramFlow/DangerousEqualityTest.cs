using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(DangerousEqualityCheckAchievement))]
    [ExpectUnlock(typeof(IfStatementAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeFloat))]
    [ExpectUnlock(typeof(DeclareInitializeDouble))]
    public class DangerousEqualityTest
    {
        public void Test()
        {
            double a = 23.2;

            if (a == 42.1)
            {
            }

            float b = 23.2F;

            if (b == 42.1F)
            {
            }

            decimal c = 23.2M;

            if (c == 42.1M)
            {
            }
        }
    }
}