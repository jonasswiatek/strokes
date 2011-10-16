using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(InheritClassAchievement))]
    public class InheritClassTest : System.Attribute
    {
    }
}