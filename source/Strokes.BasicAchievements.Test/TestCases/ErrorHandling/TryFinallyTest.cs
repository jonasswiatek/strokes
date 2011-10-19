using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ErrorHandling
{
    [ExpectUnlock(typeof(TryFinallyStatementAchievement))]
    public class TryFinallyTest
    {
        public void Main()
        {
            try
            {
            }
            finally
            {
            }
        }
    }
}