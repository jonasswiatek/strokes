using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(EnumInitializerAchievement))]
    public class EnumDeclarationTest
    {
    }
    public enum SomeEnume
    {
        Some,
        Enum,
        Blabla
    }
}