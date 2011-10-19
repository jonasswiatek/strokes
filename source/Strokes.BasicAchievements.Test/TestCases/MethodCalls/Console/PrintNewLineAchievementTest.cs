using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintNewLineAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class PrintNewLineAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("bla\n");
        }
    }
}