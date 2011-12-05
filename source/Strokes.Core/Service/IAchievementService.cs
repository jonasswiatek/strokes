using System;
using System.Collections.Generic;
using System.Reflection;
using Strokes.Core.Service.Model;
using System.Globalization;

namespace Strokes.Core.Service
{
    public interface IAchievementService
    {
        event EventHandler<AchievementEventArgs> AchievementsUnlocked;
        
        event EventHandler<EventArgs> StaticAnalysisStarted;
        
        event EventHandler<StaticAnalysisEventArgs> StaticAnalysisCompleted;

        IEnumerable<Achievement> PerformStaticAnalysis(StaticAnalysisManifest staticAnalysisManifest, bool onlyUnlockable);

        void UpdateLocalization(Achievement achievement, CultureInfo culture);

        void UnlockAchievement(AchievementBase achievement);
        
        void ResetAchievementProgress();
        
        void LoadAchievementsFrom(Assembly assembly);
        
        IEnumerable<Achievement> GetAllAchievements();
        
        IEnumerable<Achievement> GetUnlockableAchievements();
    }
}