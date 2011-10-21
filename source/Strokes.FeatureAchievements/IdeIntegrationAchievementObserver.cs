using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecube.Strokes_FeatureAchievements.IdeIntegration;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Service;
using StructureMap;

namespace Codecube.Strokes_FeatureAchievements
{
    public class IdeIntegrationAchievementObserver
    {
        protected List<IdeIntegrationAchievement> IdeIntegrationAchievements = new List<IdeIntegrationAchievement>();
        protected IAchievementService AchievementService;
        public IdeIntegrationAchievementObserver(Package shell)
        {
        }
    }
}
