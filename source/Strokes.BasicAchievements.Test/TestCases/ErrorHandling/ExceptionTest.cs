using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ErrorHandling
{
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(ThrownExceptionAchievement))]
    [ExpectUnlock(typeof(ThrownNotImplementedAchievement))]
    public class ExceptionTest
    {
        public void Main()
        {
            throw new NotImplementedException();
        }
    }
}