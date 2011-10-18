using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Expressions
{
    [ExpectUnlock(typeof(LambdaExpressionAchievement))]
    public class LambdaExpressionTest
    {
        public void Test()
        {
            System.Action lambda = () => {};
        }
    }
}
