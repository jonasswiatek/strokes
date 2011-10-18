using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(DefaultCaseInSwitchSwitchAchievement))]
    public class DefaultCaseInSwitchTest
    {
        public void Test()
        {
            int a = 0;

            switch (a)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}