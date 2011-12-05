using System.Collections.Generic;
using System.Reflection;
using Strokes.Core.Service.Model;
using System.Globalization;

namespace Strokes.Service.Data
{
    public interface IAchievementRepository
    {
        IEnumerable<Achievement> GetAchievements();
        
        IEnumerable<Achievement> GetUnlockableAchievements();

        void UpdateLocalization(Achievement achievement, CultureInfo culture);

        void MarkAchievementAsCompleted(Achievement achievement);
        
        void LoadFromAssembly(Assembly assembly);
        
        void ResetAchievements();
    }
}
