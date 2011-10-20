using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core.Service.Model
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
