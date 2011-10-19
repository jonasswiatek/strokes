using System;
using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(ArrayClearMethodAchievement))]
    [ExpectUnlock(typeof(ArrayIndexOfMethodAchievement))]
    [ExpectUnlock(typeof(ArrayReverseMethodAchievement))]
    [ExpectUnlock(typeof(ArraySortMethodAchievement))]
    [ExpectUnlock(typeof(DeclareInitArrayAchievement))]
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    public class ArrayAchievementTest
    {
        public void bla()
        {
            var arr = new[] {1, 2, 3, 4, 5};
            Array.Clear(arr, 0, 0);
            System.Array.IndexOf(arr, "");
            Array.Reverse(arr);
            Array.Sort(arr);
        }
    }
}