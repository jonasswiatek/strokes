using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(SealedMethodAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(VirtualMethodAchievement))]
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    public class SealedMethodTest
    {
        class A
        {
            public virtual void F()
            {
                
            }
            
        }
        class B : A
        {
            sealed override public void F()
            {
                
            }
           
        }
    }


}