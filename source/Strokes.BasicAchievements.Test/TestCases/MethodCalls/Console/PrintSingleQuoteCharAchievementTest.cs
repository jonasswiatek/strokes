using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintSingleQuoteCharAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    public class PrintSingleQuoteCharAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("bla: '");
        }
    }
}