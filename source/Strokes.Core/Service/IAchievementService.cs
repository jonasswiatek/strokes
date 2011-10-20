using System;
using System.Collections.Generic;
using Strokes.Core.Service.Model;

namespace Strokes.Core.Service
{
    public interface IAchievementService
    {
        event EventHandler<AchievementEventArgs> AchievementsUnlocked;
        event EventHandler<EventArgs> StaticAnalysisStarted;
        event EventHandler<StaticAnalysisEventArgs> StaticAnalysisCompleted;

        void PerformStaticAnalysis(StaticAnalysisManifest staticAnalysisManifest);
        IEnumerable<Achievement> GetAllAchievements();
        IEnumerable<Achievement> GetUnlockableAchievements();
    }
}