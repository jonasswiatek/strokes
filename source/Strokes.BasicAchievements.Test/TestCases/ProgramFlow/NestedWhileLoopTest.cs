using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(WhileLoopAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(NestedWhileStatementAchievement))]
    public class NestedWhileLoopTest
    {
        public void Test()
        {
            int i = 0;
            while (i<0)
            {
                
                while (i<0)
                {
                   
                }
            }
        }
    }
}