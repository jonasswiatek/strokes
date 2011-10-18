using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(IfElseStatementAchievement))]
    [ExpectUnlock(typeof(IfStatementAchievement))]
    public class IfElseStatementTest
    {
        public void Test()
        {
            if (false)
            {
            }
            else
            {
            }
        }
    }
}