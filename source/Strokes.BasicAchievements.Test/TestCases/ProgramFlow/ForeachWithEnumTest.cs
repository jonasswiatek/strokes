using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    public class ForTest
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