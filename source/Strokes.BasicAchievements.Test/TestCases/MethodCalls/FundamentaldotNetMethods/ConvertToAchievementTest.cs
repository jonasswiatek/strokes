using System;
using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.FundamentaldotNetMethods
{
    [ExpectUnlock(typeof(ConvertToCharAchievement))]
    [ExpectUnlock(typeof(ConvertToDecimalAchievement))]
    [ExpectUnlock(typeof(ConvertToDoubleAchievement))]
    [ExpectUnlock(typeof(ConvertToInt32Achievement))]
    public class ConvertToAchievementTest
    {
        public void bla()
        {
            Convert.ToChar("a");
            System.Convert.ToDecimal("1");
            Convert.ToDouble("1");
            Convert.ToInt32("1");
        }
    }
}