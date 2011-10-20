using System.Collections.Generic;
using System.Reflection;
using Strokes.Core.Data.Model;
using Strokes.Core.Service.Model;

namespace Strokes.Core.Data
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
