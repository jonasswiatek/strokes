using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintQuoteCharAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class PrintQuoteCharAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("bla: \"");
        }
    }
}