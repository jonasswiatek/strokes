using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(BeastNumberAchievement))]
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(AssignInt))]
    public class BeastNumberAchievementTest
    {
        public void Main()
        {
            int i;

            i = 666;
        }
    }
}