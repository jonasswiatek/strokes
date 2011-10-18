using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Expressions
{
    [ExpectUnlock(typeof(IfCompoundExpressionAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(IfStatementAchievement))]
    [ExpectUnlock(typeof(IfElseStatementAchievement))]
    [ExpectUnlock(typeof(OperatorAndAchievement))]
    [ExpectUnlock(typeof(OperatorOrAchievement))]
    public class IfCompoundExpressionTest
    {
        public void Test()
        {
            int a = 1;
            int b = 2;
            int c = 3;

            if (a == 1 && b == 2 || c == 3)
            {
            }
            else
            {
                
            }
        }
    }
}
