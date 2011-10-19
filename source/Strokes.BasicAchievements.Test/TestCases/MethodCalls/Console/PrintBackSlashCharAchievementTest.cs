using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintBackSlashCharAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class PrintBackSlashCharAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("bla: \\");
        }
    }
}