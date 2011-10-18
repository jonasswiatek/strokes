using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateAutoPropertyAchievement))]
    public class CreateAutoPropertyTest
    {
        public string SomeString { get; set; }
    }
}