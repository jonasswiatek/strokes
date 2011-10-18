using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Generic
{
    [ExpectUnlock(typeof(CreateGenericClassAchievement))]
    public class CreateGenericClassTest
    {
        public class GenericClass<T>
        {
        }
    }
}
