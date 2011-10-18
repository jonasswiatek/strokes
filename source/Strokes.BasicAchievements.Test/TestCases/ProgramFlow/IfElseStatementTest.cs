using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(IfElseStatementAchievement))]
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