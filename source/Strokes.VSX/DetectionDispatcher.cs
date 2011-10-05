using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Strokes.Core;
using Strokes.Core.Contracts;
using Strokes.Core.Model;
using Strokes.Data;
using Strokes.GUI;

namespace Strokes.VSX
{
    public class DetectionDispatcher
    {
        public static event EventHandler<DetectionCompletedEventArgs> DetectionCompleted;
        protected static void OnDetectionCompleted(object sender, DetectionCompletedEventArgs args)
        {
            if (DetectionCompleted != null)
            {
                DetectionCompleted(sender, args);
            }
        }

        /// <summary>
        /// Dispatches handling of achievement detection in the file(s) specified in the passed BuildInformation object.
        /// 
        /// This method is detection method agnostic. It simply forwards the BuildInformation object to all implementations of the Achievement class.
        /// </summary>
        /// <param name="buildInformation">Objects specifying documents to parse for achievements.</param>
        public static bool Dispatch(BuildInformation buildInformation)
        {
            AchievementContext.OnAchievementDetectionStarting(null, new EventArgs());
            var unlockedAchievements = new List<AchievementDescriptor>();
            var achievementDescriptorRepository = new AchievementDescriptorRepository(); //TODO: Resolve with IoC

            //Dispatch in a disposable context
            using (var detectionSession = new DetectionSession(buildInformation))
            {
                var achievementDescriptors = achievementDescriptorRepository.GetAll();
                var uncompletedAchievements = achievementDescriptors.Where(a => !a.IsCompleted || AchievementContext.DisablePersist);

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                //Create tasks
                var tasks = new Task[uncompletedAchievements.Count()];
                var i = 0;
                foreach (var uncompletedAchievement in uncompletedAchievements)
                {
                    var a = uncompletedAchievement;
                    tasks[i++] = Task.Factory.StartNew(() =>
                    {
                        var achievement = (Achievement)Activator.CreateInstance(a.AchievementType);

                        var achievementUnlocked = achievement.DetectAchievement(detectionSession);

                        if (achievementUnlocked)
                        {
                            a.CodeLocation = achievement.AchievementCodeLocation;
                            a.IsCompleted = true;
                            unlockedAchievements.Add(a);
                        }
                    });
                }

                //Wait for all tasks to complete.
                Task.WaitAll(tasks);
                stopWatch.Stop();
                OnDetectionCompleted(null, new DetectionCompletedEventArgs()
                {
                    AchievementsTested = uncompletedAchievements.Count(),
                    ElapsedMilliseconds = (int)stopWatch.ElapsedMilliseconds
                });
            }

            if (unlockedAchievements.Count() > 0)
            {
                // Mark the completed achievements
                foreach (var completedAchievement in unlockedAchievements)
                {
                    achievementDescriptorRepository.MarkAchievementAsCompleted(completedAchievement);
                }

                //Dispatch to event listeners
                AchievementContext.OnAchievementsUnlocked(null, unlockedAchievements);
                return true;
            }
            return false;
        }
    }

    public class DetectionCompletedEventArgs : EventArgs
    {
        public int AchievementsTested;
        public int ElapsedMilliseconds;
    }
}