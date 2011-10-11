using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareInt))]
    [ExpectUnlock(typeof(AssignInt))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    public class PrimitiveIntTest
    {
        public PrimitiveIntTest()
        {
            int i = 0;

            int k;
            k = 2;
        }
    }
}