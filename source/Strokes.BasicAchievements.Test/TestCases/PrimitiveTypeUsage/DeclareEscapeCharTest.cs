using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class DeclareEscapeCharTest
    {
        public void Main()
        {
            var bla = "Hey hey\t Rofl";
        }
    }
}