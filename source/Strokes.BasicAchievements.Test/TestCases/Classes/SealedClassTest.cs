using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(SealedClassAchievement))]
    public class SealedClassTest
    {
        sealed class A
        {
            
        }
        
    }


}