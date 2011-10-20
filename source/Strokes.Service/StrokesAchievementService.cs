using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strokes.Core;
using Strokes.Core.Data;
using Strokes.Core.Data.Model;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.Service
{
    public class StrokesAchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        public event EventHandler<AchievementEventArgs> AchievementsUnlocked;
        public event EventHandler<EventArgs> StaticAnalysisStarted;
        public event EventHandler<StaticAnalysisEventArgs> StaticAnalysisCompleted;

        public StrokesAchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        public void PerformStaticAnalysis(StaticAnalysisManifest staticAnalysisManifest)
        {
            var unlockedAchievements = new ConcurrentBag<Achievement>();
            using (var detectionSession = new StatisAnalysisSession(staticAnalysisManifest))
            {
                OnStaticAnalysisStarted(this, new EventArgs());
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var availableAchievements = _achievementRepository.GetUnlockableAchievements();

                var tasks = new Task[availableAchievements.Count()];
                var i = 0;

                foreach (var uncompletedAchievement in availableAchievements)
                {
                    var a = uncompletedAchievement;

                    tasks[i++] = Task.Factory.StartNew(() =>
                                                           {
                                                               /*   Technically we create a lot of objects all the time.
                                                                *   It's possible that these objects could have a lifespan longer than just a session.
                                                                *   However maintaining state is always a PITA */
                                                               var achievement = (StaticAnalysisAchievementBase) Activator.CreateInstance(a.AchievementType); 

                                                               if (achievement.IsAchievementUnlocked(detectionSession))
                                                               {
                                                                   a.CodeOrigin = achievement.AchievementCodeOrigin;
                                                                   a.IsCompleted = true;
                                                                   unlockedAchievements.Add(a);
                                                               }
                                                           });
                }

                Task.WaitAll(tasks);

                stopwatch.Stop();
                OnStaticAnalysisCompleted(this, new StaticAnalysisEventArgs
                {
                    AchievementsTested = availableAchievements.Count(),
                    ElapsedMilliseconds = (int)stopwatch.ElapsedMilliseconds
                });
            }

            if(unlockedAchievements.Any())
            {
                foreach (var completedAchievement in unlockedAchievements)
                {
                    _achievementRepository.MarkAchievementAsCompleted(completedAchievement);
                }

                OnAchievementsUnlocked(this, new AchievementEventArgs
                                                 {
                                                     UnlockedAchievements = unlockedAchievements
                                                 });
            }
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
