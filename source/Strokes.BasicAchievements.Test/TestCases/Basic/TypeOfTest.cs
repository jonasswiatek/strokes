using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(TypeOfAchievement))]
    public class TypeOfTest
    {
        public void Main()
        {
            var t = typeof (string);
        }
    }
}