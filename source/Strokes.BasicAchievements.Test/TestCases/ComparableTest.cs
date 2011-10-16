using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(IComparableAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(ThrownExceptionAchievement))]
    [ExpectUnlock(typeof(ThrownNotImplementedAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnIntAchievement))]
    public class ComparableTest : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}