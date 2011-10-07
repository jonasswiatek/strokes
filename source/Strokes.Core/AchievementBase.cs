using System;

namespace Strokes.Core
{
    public abstract class AchievementBase
    {
        public AchievementCodeLocation AchievementCodeLocation;

        public abstract bool DetectAchievement(DetectionSession detectionSession);
    }
}