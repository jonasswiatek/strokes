using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ErrorHandling
{
    [ExpectUnlock(typeof(TryCatchFinallyStatementAchievement))]
    [ExpectUnlock(typeof(TryCatchIgnoreStatementAchievement))]
    public class TryCatchFinallyStatementAchievementTest
    {
        public void Main()
        {
            try
            {
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}