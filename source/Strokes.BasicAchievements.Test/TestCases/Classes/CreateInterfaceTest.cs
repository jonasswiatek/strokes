using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(CreateInterfaceAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(EmptyMethodAchievement))]
    public class CreateInterfaceTest
    {
    }

    public interface ISomeInterface
    {
        void Bla();
    }
}