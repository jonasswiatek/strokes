using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Basic
{
    [ExpectUnlock(typeof(PlusOperatorAchievement))]
    [ExpectUnlock(typeof(MinusOperatorAchievement))]
    [ExpectUnlock(typeof(MultiplyOperatorAchievement))]
    [ExpectUnlock(typeof(DivideOperatorAchievement))]
    [ExpectUnlock(typeof(ModuloOperatorAchievement))]
    public class ArithmeticOperatorTest
    {
        public void Main()
        {
            var add = 1 + 2;
            var sub = 1 - 2;
            var multiply = 1 * 2;
            var divide = 2/1;
            var modulo = 10%2;
        }
    }
}