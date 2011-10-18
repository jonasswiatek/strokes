using System.Threading;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.EventsAndThreads
{
    [ExpectUnlock(typeof(CreateThreadAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(LambdaExpressionAchievement))]
    [ExpectUnlock(typeof(SleepThreadAchievement))]
    [ExpectUnlock(typeof(StartThreadAchievement))]
    [ExpectUnlock(typeof(JoinThreadAchievement))]
    [ExpectUnlock(typeof(AbortThreadAchievement))]
    public class ThreadTest
    {
        public Thread SomeThread;
        public void Main()
        {
            var someThread = new Thread(() => { });
            someThread.Start();
            someThread.Join();
            
            SomeThread = new Thread(() => { });
            SomeThread.Abort();

            Thread.Sleep(5);
        }
    }
}