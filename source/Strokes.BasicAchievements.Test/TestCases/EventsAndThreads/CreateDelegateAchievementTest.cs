using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.EventsAndThreads
{
    [ExpectUnlock(typeof(CreateDelegateAchievement))]
    public class CreateDelegateAchievementTest
    {
        public delegate void SomeDelegate(object obj, string str);
    }
}