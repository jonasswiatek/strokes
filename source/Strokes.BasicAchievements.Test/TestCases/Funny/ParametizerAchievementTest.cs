using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(ParametizerAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodMultipleParametersAchievement))]
    public class ParametizerAchievementTest
    {
        public void Method(int a, int b, int c, int d, int e, int f, int g, int h, int j, int k, int l)
        {
        }
    }
}