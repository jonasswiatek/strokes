using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(CreateThreadAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(LambdaExpressionAchievement))]
    public class CreateThreadTest
    {
        public void Main()
        {
            var thread = new System.Threading.Thread(() =>
            {
            });
        }
    }
}