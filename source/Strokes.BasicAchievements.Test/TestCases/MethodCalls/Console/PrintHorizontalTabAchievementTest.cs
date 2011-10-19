using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(PrintHorizontalTabAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class PrintHorizontalTabAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("bla\t");
        }
    }
}