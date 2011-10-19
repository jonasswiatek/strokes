using Strokes.BasicAchievements.Achievements;
using Strokes.BasicAchievements.Achievements.MethodCalls;

namespace Strokes.BasicAchievements.Test.TestCases.MethodCalls.MethodBasics
{
    [ExpectUnlock(typeof(CreateStaticMethodAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(TooManyModifiersMethodDeclarationAchievement))]
    public class CreateStaticMethodAchievementTest
    {
        public static void bla(string someOutParam)
        {
        }
    }
}