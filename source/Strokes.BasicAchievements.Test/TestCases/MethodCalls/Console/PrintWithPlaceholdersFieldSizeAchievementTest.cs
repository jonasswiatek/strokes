using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintWithPlaceholdersFieldSizeAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(PrintWithPlaceholdersAchievement))]
    [ExpectUnlock(typeof(FormatSpecifierAchievement))]
    public class PrintWithPlaceholdersFieldSizeAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("Some value: {0:D,5}", 1);
        }
    }
}