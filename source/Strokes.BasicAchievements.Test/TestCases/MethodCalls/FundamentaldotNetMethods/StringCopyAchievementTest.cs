using System;
using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(StringCopyAchievement))]
    public class StringCopyAchievementTest
    {
        public void bla()
        {
            var bla = String.Copy("str");
        }
    }
}