using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.EventsAndThreads
{
    [ExpectUnlock(typeof(UnSubscribeToEventAchievement))]
    [ExpectUnlock(typeof(CreateEventAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodMultipleParametersAchievement))]
    public class EventUnsubscriptionTest
    {
        public event EventHandler<EventArgs> SomeEvent;

        public void Main()
        {
            SomeEvent -= EventHandler;
        }

        private void EventHandler(object sender, EventArgs e)
        {
        }
    }
}