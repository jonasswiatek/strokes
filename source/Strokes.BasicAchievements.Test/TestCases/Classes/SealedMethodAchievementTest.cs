using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(SealedMethodAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(VirtualMethodAchievement))]
    [ExpectUnlock(typeof(TooManyModifiersMethodDeclarationAchievement))]
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    public class SealedMethodAchievementTest : blaClass
    {
        public sealed override void bla()
        {
            
        }
    }

    public class blaClass
    {
        public virtual void bla()
        {

        }
    }
}