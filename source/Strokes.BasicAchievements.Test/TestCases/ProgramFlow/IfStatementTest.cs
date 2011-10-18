using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(IfStatementAchievement))]
    public class IfStatementTest
    {
        public void Test()
        {
            if (true)
            {
            }
        }
    }
}