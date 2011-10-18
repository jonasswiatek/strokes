using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnStringAchievement))]
    public class OverrideMethodTest : VirtualMethodTest
    {
        public override string SomeMethod()
        {
            return string.Empty;
        }
    }
}