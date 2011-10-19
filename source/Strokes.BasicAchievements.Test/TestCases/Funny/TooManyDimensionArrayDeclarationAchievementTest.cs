using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(TooManyDimensionArrayDeclarationAchievement))]
    public class TooManyDimensionArrayDeclarationAchievementTest
    {
        public void Main()
        {
            var arr = new int[1,2,3,4,5,6,7,8,9,0,9,8,6];
        }
    }
}