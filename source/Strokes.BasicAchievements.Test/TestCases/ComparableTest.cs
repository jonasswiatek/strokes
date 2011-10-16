using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(IComparableAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    public class ComparableTest : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}