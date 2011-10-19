using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(TooManyModifiersMethodDeclarationAchievement))]
    [ExpectUnlock(typeof(EmptyVoidMethodAchievement))]
    [ExpectUnlock(typeof(VirtualMethodAchievement))]
    public class TooManyModifiersMethodDeclarationAchievementTest
    {
        public virtual void Method()
        {
        }
    }
}