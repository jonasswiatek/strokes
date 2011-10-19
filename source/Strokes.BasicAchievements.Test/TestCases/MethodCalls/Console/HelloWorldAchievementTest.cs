using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(HelloWorldAchievement))]
    [ExpectUnlock(typeof(PrintToConsoleAchievement))]
    public class HelloWorldAchievementTest
    {
        public void Main()
        {
            System.Console.WriteLine("hello world");
        }
    }
}