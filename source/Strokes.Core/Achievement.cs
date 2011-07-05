using System;

namespace Strokes.Core
{
    public abstract class Achievement
    {
        public abstract bool DetectAchievement(DetectionSession detectionSession);
    }
}