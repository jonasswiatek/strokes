using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.Console
{
    [ExpectUnlock(typeof(UseConsoleReadlineAchievement))]
    public class UseConsoleReadlineAchievementTest
    {
        public void Main()
        {
            System.Console.ReadLine();
        }
    }
}