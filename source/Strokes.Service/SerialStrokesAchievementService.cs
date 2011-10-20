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
    public class SerialStrokesAchievementService : StrokesAchievementServiceBase
    {
        public SerialStrokesAchievementService(IAchievementRepository achievementRepository)
            : base(achievementRepository)
        {
        }

        protected override IEnumerable<Achievement> GetUnlockedAchievements(StatisAnalysisSession statisAnalysisSession, IEnumerable<Achievement> availableAchievements)
        {
            var unlockedAchievements = new List<Achievement>();
            foreach (var uncompletedAchievement in availableAchievements)
            {
                var a = uncompletedAchievement;

                var achievement = (StaticAnalysisAchievementBase)Activator.CreateInstance(a.AchievementType);

                if (achievement.IsAchievementUnlocked(statisAnalysisSession))
                {
                    a.CodeOrigin = achievement.AchievementCodeOrigin;
                    a.IsCompleted = true;
                    unlockedAchievements.Add(a);
                }
            }

            return unlockedAchievements;
        }
    }
}
