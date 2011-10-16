using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(TryCatchIgnoreStatementAchievement))]
    [ExpectUnlock(typeof(TryCatchStatementAchievement))]
    [ExpectUnlock(typeof(TryCatchRethrowStatementAchievement))]
    public class TryCatchIgnoreTest
    {
        public void Main()
        {
            try
            {
            }
            catch(ArgumentException e)
            {
                throw;
            }
            catch
            {
            }
        }
    }
}