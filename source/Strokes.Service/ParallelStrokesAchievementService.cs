using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;
using Strokes.Service.Data;

namespace Strokes.Service
{
    public class ParallelStrokesAchievementService : StrokesAchievementServiceBase
    {
        public ParallelStrokesAchievementService(IAchievementRepository achievementRepository) : base(achievementRepository)
        {
        }

        protected override IEnumerable<Achievement> GetUnlockedAchievements(StatisAnalysisSession statisAnalysisSession, IEnumerable<Achievement> availableAchievements)
        {
            var unlockedAchievements = new List<Achievement>();
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
                    var achievement = (StaticAnalysisAchievementBase)Activator.CreateInstance(a.AchievementType);

                    if (achievement.IsAchievementUnlocked(statisAnalysisSession))
                    {
                        a.CodeOrigin = achievement.AchievementCodeOrigin;
                        a.IsCompleted = true;
                        unlockedAchievements.Add(a);
                    }
                });
            }

            Task.WaitAll(tasks);

            return unlockedAchievements;
        }
    }
}
