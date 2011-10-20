using System;
using Strokes.Core.Service.Model;

namespace Strokes.Core
{
    public abstract class StaticAnalysisAchievementBase
    {
        public AchievementCodeOrigin AchievementCodeOrigin;

        public abstract bool IsAchievementUnlocked(StatisAnalysisSession statisAnalysisSession);
    }
}