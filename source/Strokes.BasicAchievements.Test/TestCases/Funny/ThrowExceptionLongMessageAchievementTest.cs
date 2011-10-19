using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(ThrowExceptionLongMessageAchievement))]
    [ExpectUnlock(typeof(ThrownExceptionAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    public class ThrowExceptionLongMessageAchievementTest
    {
        public void Method()
        {
            throw new Exception("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
        }
    }
}