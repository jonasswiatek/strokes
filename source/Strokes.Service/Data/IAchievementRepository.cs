using System.Collections.Generic;
using System.Reflection;
using Strokes.Core.Service.Model;

namespace Strokes.Service.Data
{
    public interface IAchievementRepository
    {
        IEnumerable<Achievement> GetAchievements();
        IEnumerable<Achievement> GetUnlockableAchievements();

        void MarkAchievementAsCompleted(Achievement achievement);
        void LoadFromAssembly(Assembly assembly);
        void ResetAchievements();
    }
}
