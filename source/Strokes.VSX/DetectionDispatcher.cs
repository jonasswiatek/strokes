using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Strokes.Core;
using Strokes.Core.Contracts;
using Strokes.Core.Model;
using Strokes.Data;
using Strokes.GUI;

namespace Strokes.VSX
{
    public class DetectionDispatcher
    {
        /// <summary>
        /// Dispatches handling of achievement detection in the file(s) specified in the passed BuildInformation object.
        /// 
        /// This method is detection method agnostic. It simply forwards the BuildInformation object to all implementations of the Achievement class.
        /// </summary>
        /// <param name="buildInformation">Objects specifying documents to parse for achievements.</param>
        public bool Dispatch(BuildInformation buildInformation)
        {
            var unlockedAchievements = new List<AchievementDescriptor>();
            var achievementDescriptorRepository = new AchievementDescriptorRepository(); //TODO: Resolve with IoC

            //Dispatch in a disposable context
            using (var detectionSession = new DetectionSession(buildInformation))
            {
                var achievementDescriptors = achievementDescriptorRepository.GetAll();

                var uncompletedAchievements = achievementDescriptors.Where(a => !a.IsCompleted || AchievementContext.DisablePersist);

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                foreach (var achievementDescriptor in uncompletedAchievements)
                {
                    var achievement = (Achievement)Activator.CreateInstance(achievementDescriptor.AchievementType);

                    var achievementUnlocked = achievement.DetectAchievement(detectionSession);

                    if (achievementUnlocked)
                    {
                        achievementDescriptor.IsCompleted = true;
                        unlockedAchievements.Add(achievementDescriptor);
                    }
                }
                stopWatch.Stop();
                var dispatchTimeElapsed = stopWatch.ElapsedMilliseconds;
                Trace.WriteLine("Detection time elapsed: " + dispatchTimeElapsed);
            }

            if(unlockedAchievements.Count() > 0)
            {
                //Mark the completed achievements
                foreach(var completedAchievement in unlockedAchievements)
                {
                    achievementDescriptorRepository.MarkAchievementAsCompleted(completedAchievement);
                }

                //Dispatch to event listeners
                AchievementContext.OnAchievementsUnlocked(this, unlockedAchievements);
                return true;
            }
            return false;
        }
    }
}