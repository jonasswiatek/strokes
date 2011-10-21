using System;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.Core
{
    public abstract class StaticAnalysisAchievementBase : AchievementBase
    {
        public AchievementCodeOrigin AchievementCodeOrigin;

        public abstract bool IsAchievementUnlocked(StatisAnalysisSession statisAnalysisSession);
    }
}