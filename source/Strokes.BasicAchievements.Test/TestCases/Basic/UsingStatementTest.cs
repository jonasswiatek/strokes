using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(UsingStatementAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    public class UsingStatementTest : IDisposable
    {
        public void Main()
        {
            using(var bla = new UsingStatementTest())
            {
                
            }
        }

        public void Dispose()
        {
        }
    }
}