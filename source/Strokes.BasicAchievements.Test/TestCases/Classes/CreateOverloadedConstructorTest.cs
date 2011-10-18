using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateConstructorAchievement))]
    [ExpectUnlock(typeof(CreateDefaultConstructorAchievement))]
    [ExpectUnlock(typeof(CreateOverloadedConstructorAchievement))]
    public class CreateOverloadedConstructorTest
    {
        public CreateOverloadedConstructorTest()
        {
        }

        public CreateOverloadedConstructorTest(string bla)
        {
        }
    }
}