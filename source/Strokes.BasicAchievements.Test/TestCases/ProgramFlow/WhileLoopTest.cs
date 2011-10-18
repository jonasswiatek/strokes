using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(WhileLoopAchievement))]
    public class WhileLoopTest
    {
        public void Test()
        {
            int i = 0;
            while (i < 10)
            {
                i++;
            }
        }
    }
}