using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateBaseConstructorInitAchievement))]
    [ExpectUnlock(typeof(CreateConstructorAchievement))]
    [ExpectUnlock(typeof(CreateDefaultConstructorAchievement))]
    public class CreateBaseConstructorInitTest : SomeBaseClass
    {
        public CreateBaseConstructorInitTest() : base()
        {
        }
    }

    public class SomeBaseClass
    {
    }
}