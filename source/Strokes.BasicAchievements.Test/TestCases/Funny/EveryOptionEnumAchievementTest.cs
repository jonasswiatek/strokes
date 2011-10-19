using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(EveryOptionEnumAchievement))]
    [ExpectUnlock(typeof(EnumInitializerAchievement))]
    public class EveryOptionEnumAchievementTest
    {
    }

    public enum SomeEnum
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K
    }
}