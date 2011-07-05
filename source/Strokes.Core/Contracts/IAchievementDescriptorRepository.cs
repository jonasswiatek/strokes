using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Strokes.Core.Model;

namespace Strokes.Core.Contracts
{
    public interface IAchievementDescriptorRepository
    {
        IEnumerable<AchievementDescriptor> GetAll();
        void MarkAchievementAsCompleted(AchievementDescriptor achievement);

        void LoadFromAssembly(Assembly assembly);
    }
}
