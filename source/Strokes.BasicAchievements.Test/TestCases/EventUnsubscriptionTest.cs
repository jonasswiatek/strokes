using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(UnSubscribeToEventAchievement))]
    [ExpectUnlock(typeof(CreateEventAchievement))]
    [ExpectUnlock(typeof(LambdaExpressionAchievement))]
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