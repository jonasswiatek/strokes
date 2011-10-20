using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Data.Model;

namespace Strokes.Core.Service.Model
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
