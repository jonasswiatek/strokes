using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(EnumSwitchAchievement))]
    [ExpectUnlock(typeof(SwitchAchievement))]
    [ExpectUnlock(typeof(EnumInitializerAchievement))]
    public class EnumSwitchTest
    {
        public enum FooBarBaz
        {
            Foo,
            Bar,
            Baz
        }
        
        public void Test()
        {
            FooBarBaz a = FooBarBaz.Foo;

            switch (a)
            {
                case FooBarBaz.Foo:
                    break;
                case FooBarBaz.Bar:
                    break;
                case FooBarBaz.Baz:
                    break;
            }
        }
    }
}