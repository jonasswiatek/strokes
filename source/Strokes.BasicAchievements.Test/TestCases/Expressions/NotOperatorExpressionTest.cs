using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Expressions
{
    [ExpectUnlock(typeof(NotOperatorAchievement))]
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
