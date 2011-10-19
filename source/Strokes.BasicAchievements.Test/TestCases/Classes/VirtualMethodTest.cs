using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(VirtualMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnStringAchievement))]
    [ExpectUnlock(typeof(TooManyModifiersMethodDeclarationAchievement))]
    [ExpectUnlock(typeof(CreateSingleLineMethodAchievement))]
    public class VirtualMethodTest
    {
        public virtual string SomeMethod()
        {
            return string.Empty;
        }
    }
}