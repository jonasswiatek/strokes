using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(NestedIfStatementAchievement))]
    [ExpectUnlock(typeof(IfStatementAchievement))]
    public class NestedIfStatementTest
    {
        public void Test()
        {
            if (true)
            {
                if (false)
                {
                }
            }
        }
    }
}