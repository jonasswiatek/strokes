using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(AbstractClassAchievement))]
    [ExpectUnlock(typeof(AbstractMethodAchievement))]
    [ExpectUnlock(typeof(EmptyMethodAchievement))]
    public abstract class AbstractClassTest
    {
        public abstract void SomeMethod();

        public void EmptyMethod()
        {
        }
    }
}