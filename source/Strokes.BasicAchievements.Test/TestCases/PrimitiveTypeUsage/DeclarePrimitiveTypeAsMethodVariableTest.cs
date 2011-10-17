using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(DeclareDouble))]
    [ExpectUnlock(typeof(DeclareFloat))]
    [ExpectUnlock(typeof(DeclareChar))]
    public class DeclarePrimitiveTypeAsMethodVariableTest
    {
        public void Main()
        {
            int intVar;
            float floatVar;
            double doubleVar;
            char charVar;
        }
    }
}