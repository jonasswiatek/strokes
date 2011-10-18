using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(EnumInitializerAchievement))]
    [ExpectUnlock(typeof(EnumInitializerExplicitAchievement))]
    public class EnumExplicitDeclarationTest
    {
    }
    public enum SomeEnum
    {
        Some = 1,
        Enum = 2,
        Blabla = 3
    }
}