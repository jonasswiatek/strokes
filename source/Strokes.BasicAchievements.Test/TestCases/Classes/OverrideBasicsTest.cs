using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Classes
{
    [ExpectUnlock(typeof(OverrideEqualsAchievement))]
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    [ExpectUnlock(typeof(OverrideGetHashCodeAchievement))]
    [ExpectUnlock(typeof(OverrideToStringAchievement))]
    [ExpectUnlock(typeof(CreateMethodOneParameterAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnIntAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnBoolAchievement))]
    [ExpectUnlock(typeof(CreateMethodReturnStringAchievement))]
    public class OverrideBasicsTest
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}