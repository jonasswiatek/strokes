using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(LowerBoundaryValueInt))]
    [ExpectUnlock(typeof(LowerBoundaryValueDouble))]
    [ExpectUnlock(typeof(LowerBoundaryValueFloat))]
    [ExpectUnlock(typeof(LowerBoundaryValueChar))]
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(DeclareDouble))]
    [ExpectUnlock(typeof(DeclareFloat))]
    [ExpectUnlock(typeof(DeclareChar))]
    public class LowerBoundAssignValueToPrimitiveType
    {
        int intVar;
        float floatVar;
        double doubleVar;
        char charVar;

        public void Main()
        {
            intVar = int.MinValue;
            floatVar = float.MinValue;
            doubleVar = double.MinValue;
            charVar = char.MinValue;
        }
    }
}