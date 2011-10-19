using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(EmptyMainAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    public class EmptyMainAchievementTest
    {
        public void Main()
        {
        }
    }
}