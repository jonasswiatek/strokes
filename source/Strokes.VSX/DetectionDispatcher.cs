using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Strokes.Core;
using Strokes.Core.Data;
using Strokes.Core.Data.Model;
using Strokes.Data;
using Strokes.GUI;
using StructureMap;

namespace Strokes.VSX
{
    public class DetectionDispatcher
    {
        /// <summary>
        /// Occours when the achievement detection have completed.
        /// </summary>
        public static event EventHandler<DetectionCompletedEventArgs> DetectionCompleted;

        /// <summary>
        /// Called when the achievement detection have completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">
        ///     The <see cref="Strokes.VSX.DetectionCompletedEventArgs"/> instance containing the event data.
        /// </param>
        protected static void OnDetectionCompleted(object sender, DetectionCompletedEventArgs args)
        {
            if (DetectionCompleted != null)
            {
                DetectionCompleted(sender, args);
            }
        }

        /// <summary>
        /// Dispatches handling of achievement detection in the file(s) specified 
        /// in the passed BuildInformation object.
        /// 
        /// This method is detection method agnostic. It simply forwards the 
        /// BuildInformation object to all implementations of the Achievement class.
        /// </summary>
        /// <param name="buildInformation">
        ///     Objects specifying documents to parse for achievements.
        /// </param>
        public static bool Dispatch(BuildInformation buildInformation)
        {
            AchievementContext.OnAchievementDetectionStarting(null, new EventArgs());

            var unlockedAchievements = new List<Achievement>();
            var achievementDescriptorRepository = ObjectFactory.GetInstance<IAchievementRepository>();

            using (var detectionSession = new DetectionSession(buildInformation))
            {
                var unlockableAchievements = achievementDescriptorRepository.GetUnlockableAchievements();

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var tasks = new Task[unlockableAchievements.Count()];
                var i = 0;

                foreach (var uncompletedAchievement in unlockableAchievements)
                {
                    var a = uncompletedAchievement;

                    tasks[i++] = Task.Factory.StartNew(() =>
                    {
                        var achievement = (AchievementBase)Activator.CreateInstance(a.AchievementType);

                        var achievementUnlocked = achievement.DetectAchievement(detectionSession);

                        if (achievementUnlocked)
                        {
                            a.CodeLocation = achievement.AchievementCodeLocation;
                            a.IsCompleted = true;
                            unlockedAchievements.Add(a);
                        }
                    });
                }

                Task.WaitAll(tasks);

                stopWatch.Stop();

                OnDetectionCompleted(null, new DetectionCompletedEventArgs()
                {
                    AchievementsTested = unlockableAchievements.Count(),
                    ElapsedMilliseconds = (int)stopWatch.ElapsedMilliseconds
                });
            }

            if (unlockedAchievements.Count() > 0)
            {
                foreach (var completedAchievement in unlockedAchievements.Where(a => a != null))
                {
                    achievementDescriptorRepository.MarkAchievementAsCompleted(completedAchievement);
                }

                AchievementContext.OnAchievementsUnlocked(null, unlockedAchievements);

                return true;
            }

            return false;
        }
    }

    public class DetectionCompletedEventArgs : EventArgs
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