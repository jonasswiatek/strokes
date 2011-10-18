using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(PrivateSetterAchievement))]
    [ExpectUnlock(typeof(CreatePropertyAchievement))]
    [ExpectUnlock(typeof(CreateAutoPropertyAchievement))]
    public class PrivateSetterTest
    {
        public string SomeString { get; private set; }
    }
}