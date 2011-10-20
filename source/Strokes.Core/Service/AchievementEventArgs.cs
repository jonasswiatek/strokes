using System;
using System.Collections.Generic;
using Strokes.Core.Service.Model;

namespace Strokes.Core.Service
{
    public class AchievementEventArgs : EventArgs
    {
        public IEnumerable<Achievement> UnlockedAchievements
        {
            get;
            set;
        }
    }
}
