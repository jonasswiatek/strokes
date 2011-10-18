using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(ForAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(PlusPlusOperatorAchievement))]
    public class ForTest
    {
        public void Test()
        {
            for (int index = 0; index < 20; index++)
            {
                
            }
        }
    }
}