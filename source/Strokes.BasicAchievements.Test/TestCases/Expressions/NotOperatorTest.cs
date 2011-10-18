using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Expressions
{
    [ExpectUnlock(typeof(NotOperatorAchievement))]
    [ExpectUnlock(typeof(IfStatementAchievement))]
    public class NotOperatorTest
    {
        public void Test()
        {
            bool test = false;
            
            if (!test)
            {
            }
        }
    }
}
