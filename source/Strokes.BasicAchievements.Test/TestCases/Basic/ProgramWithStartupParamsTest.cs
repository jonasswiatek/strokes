using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(ProgramWithStartupParamsAchievement))]
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    public class ProgramWithStartupParamsTest
    {
        public static void Main(string[] args)
        {
            var bla = args[0];
        }
    }
}