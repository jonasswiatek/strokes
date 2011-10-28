using System.Threading;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.EventsAndThreads
{
    [ExpectUnlock(typeof(SleepThreadAchievement))]
    public class ThreadBorderCaseOneTest
    {
        public void Main()
        {
            System.Threading.Thread.Sleep(5);
        }
    }
}