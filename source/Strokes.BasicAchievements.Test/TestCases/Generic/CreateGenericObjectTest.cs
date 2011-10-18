using Strokes.BasicAchievements.Achievements;
using System.Collections.Generic;

namespace Strokes.BasicAchievements.Test.TestCases.Generic
{
    [ExpectUnlock(typeof(CreateGenericObjectAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    public class CreateGenericObjectTest
    {
        public void Test()
        {
            List<int> test = new List<int>();
        }
    }
}
