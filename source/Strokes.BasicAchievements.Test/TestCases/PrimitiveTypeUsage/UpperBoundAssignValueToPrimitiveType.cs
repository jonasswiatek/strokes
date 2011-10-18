using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(UpperBoundaryValueInt))]
    [ExpectUnlock(typeof(UpperBoundaryValueDouble))]
    [ExpectUnlock(typeof(UpperBoundaryValueFloat))]
    [ExpectUnlock(typeof(UpperBoundaryValueChar))]
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(DeclareDouble))]
    [ExpectUnlock(typeof(DeclareFloat))]
    [ExpectUnlock(typeof(DeclareChar))]
    public class UpperBoundAssignValueToPrimitiveType
    {
        int intVar;
        float floatVar;
        double doubleVar;
        char charVar;

        public void Main()
        {
            intVar = int.MaxValue;
            floatVar = float.MaxValue;
            doubleVar = double.MaxValue;
            charVar = char.MaxValue;
        }
    }
}