using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(CastAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    public class CastTest
    {
        public void Main()
        {
            var bla = new CastTest();
            var kk = (object)bla;
        }
    }
}