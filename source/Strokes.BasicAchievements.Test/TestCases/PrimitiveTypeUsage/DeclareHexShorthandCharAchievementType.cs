using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(DeclareHexShorthandCharAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeChar))]
    [ExpectUnlock(typeof(DeclareEscapeCharAchievement))]
    public class DeclareHexShorthandCharAchievementType
    {
        public void Main()
        {
            char c = '\x0001';
        }
    }
}