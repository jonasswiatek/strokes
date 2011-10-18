using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateAutoPropertyAchievement))]
    [ExpectUnlock(typeof(CreatePropertyAchievement))]
    public class CreateAutoPropertyTest
    {
        public string SomeString { get; set; }
    }
}