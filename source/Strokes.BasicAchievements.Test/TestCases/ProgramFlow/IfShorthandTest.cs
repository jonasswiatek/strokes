using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(IfShorthandAchievement))]
    public class IfShorthandTest
    {
        public void Test()
        {
            int a = 2;
            bool b = a == 3 ? true : false;
        }
    }
}