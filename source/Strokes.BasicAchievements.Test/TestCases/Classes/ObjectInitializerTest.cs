using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(InstantiateObjectWithInitAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(DeclareInt))]
    public class ObjectInitializerTest
    {
        public int Val;

        public void Main()
        {
            var instance = new ObjectInitializerTest
            {
                Val = 3
            };
        }
    }
}