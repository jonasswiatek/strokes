using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(ForEachAchievement))]
    public class ForeachTest
    {
        public void Test()
        {
            foreach (var i in System.Linq.Enumerable.Range(0, 10))
            {
            }
        }
    }
}