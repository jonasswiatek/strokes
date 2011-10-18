using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(DestructorAchievement))]
    public class DestructorTest
    {
        ~DestructorTest()
        {
        }
    }
}