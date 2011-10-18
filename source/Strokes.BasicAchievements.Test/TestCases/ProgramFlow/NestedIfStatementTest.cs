using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
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