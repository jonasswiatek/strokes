using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(AbstractClassAchievement))]
    [ExpectUnlock(typeof(AbstractMethodAchievement))]
    [ExpectUnlock(typeof(EmptyMethodAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(TooManyModifiersMethodDeclarationAchievement))]
    public abstract class AbstractClassTest
    {
        public abstract void SomeMethod();

        public void EmptyMethod()
        {
        }
    }
}