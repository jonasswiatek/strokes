using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(InfiniteWhileLoopAchievement))]
    [ExpectUnlock(typeof(WhileLoopAchievement))]
    public class InfiniteWhileLoopAchievementTest
    {
        public void Main()
        {
            while(true)
            {
            }
        }
    }
}