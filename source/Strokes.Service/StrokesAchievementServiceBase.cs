using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;
using Strokes.Service.Data;

namespace Strokes.Service
{
    public abstract class StrokesAchievementServiceBase : IAchievementService
    {
        protected readonly IAchievementRepository AchievementRepository;
        public event EventHandler<AchievementEventArgs> AchievementsUnlocked;
        public event EventHandler<EventArgs> StaticAnalysisStarted;
        public event EventHandler<StaticAnalysisEventArgs> StaticAnalysisCompleted;

        protected StrokesAchievementServiceBase(IAchievementRepository achievementRepository)
        {
            AchievementRepository = achievementRepository;
        }

        public IEnumerable<Achievement> PerformStaticAnalysis(StaticAnalysisManifest staticAnalysisManifest, bool onlyUnlockable)
        {
            IEnumerable<Achievement> unlockedAchievements;
            using (var statisAnalysisSession = new StatisAnalysisSession(staticAnalysisManifest))
            {
                OnStaticAnalysisStarted(this, new EventArgs());
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var allAchievements = onlyUnlockable ? AchievementRepository.GetUnlockableAchievements() : AchievementRepository.GetAchievements();
                var availableStaticAnalysisAchievements = allAchievements.Where(a => typeof(StaticAnalysisAchievementBase).IsAssignableFrom(a.AchievementType)).ToList();
                
                unlockedAchievements = GetUnlockedAchievements(statisAnalysisSession, availableStaticAnalysisAchievements).ToList();

                stopwatch.Stop();
                OnStaticAnalysisCompleted(this, new StaticAnalysisEventArgs
                {
                    AchievementsTested = availableStaticAnalysisAchievements.Count(),
                    ElapsedMilliseconds = (int)stopwatch.ElapsedMilliseconds
                });
            }

            if(unlockedAchievements.Any())
            {
                foreach (var completedAchievement in unlockedAchievements)
                {
                    AchievementRepository.MarkAchievementAsCompleted(completedAchievement);
                }

                OnAchievementsUnlocked(this, new AchievementEventArgs
                                                 {
                                                     UnlockedAchievements = unlockedAchievements
                                                 });
            }
            return unlockedAchievements;
        }

        protected abstract IEnumerable<Achievement> GetUnlockedAchievements(StatisAnalysisSession statisAnalysisSession, IEnumerable<Achievement> availableAchievements);

        public void ResetAchievementProgress()
        {
            AchievementRepository.ResetAchievements();
        }

        public void LoadAchievementsFrom(Assembly assembly)
        {
            AchievementRepository.LoadFromAssembly(assembly);
        }

        public IEnumerable<Achievement> GetAllAchievements()
        {
            return AchievementRepository.GetAchievements();
        }

        public IEnumerable<Achievement> GetUnlockableAchievements()
        {
            return AchievementRepository.GetUnlockableAchievements();
        }

        #region Event Dispatchers
        private void OnAchievementsUnlocked(object sender, AchievementEventArgs e)
        {
            if(AchievementsUnlocked != null)
            {
                AchievementsUnlocked(sender, e);
            }
        }

        private void OnStaticAnalysisStarted(object sender, EventArgs e)
        {
            if(StaticAnalysisStarted != null)
            {
                StaticAnalysisStarted(sender, e);
            }
        }

        private void OnStaticAnalysisCompleted(object sender, StaticAnalysisEventArgs e)
        {
            if(StaticAnalysisCompleted != null)
            {
                StaticAnalysisCompleted(sender, e);
            }
        }
        #endregion
    }
}
