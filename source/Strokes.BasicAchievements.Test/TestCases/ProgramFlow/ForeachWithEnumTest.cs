using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(ForEachWithEnumAchievement))]
    [ExpectUnlock(typeof(EnumInitializerAchievement))]
    [ExpectUnlock(typeof(ForEachAchievement))]
    public class ForeachWithEnumTest
    {
        public enum FooBarBaz
        {
            Foo,
            Bar,
            Baz
        }

        public void Test()
        {
            foreach (FooBarBaz item in System.Enum.GetValues(typeof(FooBarBaz)))
            {
            }
        }
    }
}