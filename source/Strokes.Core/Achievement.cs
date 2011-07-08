using System;

namespace Strokes.Core
{
    public abstract class Achievement
    {
        public AchievementCodeLocation AchievementCodeLocation;

        public abstract bool DetectAchievement(DetectionSession detectionSession);
    }
}