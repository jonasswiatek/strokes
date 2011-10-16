using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(OverrideEqualsAchievement))]
    [ExpectUnlock(typeof(OverrideMethodAchievement))]
    [ExpectUnlock(typeof(OverrideGetHashCodeAchievement))]
    [ExpectUnlock(typeof(OverrideToStringAchievement))]
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