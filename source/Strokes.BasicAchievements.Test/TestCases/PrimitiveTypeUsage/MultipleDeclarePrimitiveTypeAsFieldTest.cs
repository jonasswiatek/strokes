using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(MultipleDeclareInt))]
    [ExpectUnlock(typeof(MultipleDeclareDouble))]
    [ExpectUnlock(typeof(MultipleDeclareFloat))]
    [ExpectUnlock(typeof(MultipleDeclareChar))]
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(DeclareDouble))]
    [ExpectUnlock(typeof(DeclareFloat))]
    [ExpectUnlock(typeof(DeclareChar))]
    public class MultipleDeclarePrimitiveTypeAsFieldTest
    {
        int intVar, intVar2;
        float floatVar, floatVar2;
        double doubleVar, doubleVar2;
        char charVar, charVar2;
    }
}