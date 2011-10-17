using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.PrimitiveTypeUsage
{
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(DeclareInitializeDouble))]
    [ExpectUnlock(typeof(DeclareInitializeFloat))]
    [ExpectUnlock(typeof(DeclareInitializeChar))]
    public class DeclareInitializePrimitiveTypeAsFieldTest
    {
        int intVar = 0;
        float floatVar = 1f;
        double doubleVar = 1d;
        char charVar = 'c';
    }
}