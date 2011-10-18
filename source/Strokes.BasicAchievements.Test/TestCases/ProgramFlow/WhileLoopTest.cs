using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(WhileLoopAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(PlusPlusOperatorAchievement))]
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