using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateConstructorAchievement))]
    [ExpectUnlock(typeof(CreateDefaultConstructorAchievement))]
    [ExpectUnlock(typeof(CreateOverloadedConstructorAchievement))]
    [ExpectUnlock(typeof(CreateThisConstructorInitAchievement))]
    public class CreateThisConstructorInitTest
    {
        public CreateThisConstructorInitTest() : this("text")
        {
        }

        public CreateThisConstructorInitTest(string bla)
        {
        }
    }
}