using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(ElseIfStatementAchievement))]
    public class ElseIfStatementTest
    {
        public void Test()
        {
            if (false)
            {
            }
            else if (true)
            {
            }
        }
    }
}