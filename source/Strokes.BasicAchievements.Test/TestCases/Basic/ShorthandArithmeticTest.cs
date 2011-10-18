using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(PlusPlusOperatorAchievement))]
    [ExpectUnlock(typeof(MinusMinusOperatorAchievement))]
    public class ShorthandArithmeticTest
    {
        public void Main()
        {
            int i = 0;
            i++;
            i--;
        }
    }
}