using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    public class DangerousEqualityTest
    {
        public void Test()
        {
            int a = 2;
            bool b = a == 3 ? true : false;
        }
    }
}