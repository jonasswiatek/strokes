using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(ExtensionMethodAchievement))]
    public static class ExtensionMethodTest
    {
        public static string GetSomething(this string str)
        {
            return string.Empty;
        }
    }
}