using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(SubscribeToEventAchievement))]
    [ExpectUnlock(typeof(CreateEventAchievement))]
    [ExpectUnlock(typeof(LambdaExpressionAchievement))]
    public class EventSubscriptionTest
    {
        public event EventHandler<EventArgs> SomeEvent;

        public void Main()
        {
            SomeEvent += (sender, args) =>
            {
            };
        }
    }
}