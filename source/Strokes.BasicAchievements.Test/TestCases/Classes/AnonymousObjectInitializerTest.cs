using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(AnonymousObjectAchievement))]
    public class AnonymousObjectInitializerTest
    {
        public void Main()
        {
            var anon = new
            {
                b = ""
            };
        }
    }
}