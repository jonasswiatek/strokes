using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreatePropertyAchievement))]
    public class CreatePropertyTest
    {
        public string SomeString { get { return ""; } }
    }
}