using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(GotoAchievement))]
    public class GotoAchievementTest
    {
        public void Method()
        {
            goto Finish;

            Finish:
                var bla = "";
        }
    }
}