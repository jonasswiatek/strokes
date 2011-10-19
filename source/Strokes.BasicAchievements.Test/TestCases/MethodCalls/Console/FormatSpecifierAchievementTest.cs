using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(FormatSpecifierAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(PrintWithPlaceholdersAchievement))]
    public class FormatSpecifierAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("Some value: {0:D}", 1);
        }
    }
}