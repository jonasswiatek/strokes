using System;

namespace Strokes.Core.Service
{
    public class StaticAnalysisEventArgs : EventArgs
    {
        public int AchievementsTested
        {
            get;
            set;
        }

        public int ElapsedMilliseconds
        {
            get;
            set;
        }
    }
}
