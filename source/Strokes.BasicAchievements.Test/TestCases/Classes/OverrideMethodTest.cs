using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnStringAchievement))]
    [ExpectUnlock(typeof(CreateSingleLineMethodAchievement))]
    public class OverrideMethodTest : VirtualMethodTest
    {
        public override string SomeMethod()
        {
            return string.Empty;
        }
    }
}