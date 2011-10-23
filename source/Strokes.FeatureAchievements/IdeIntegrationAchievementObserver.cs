using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Service;
using Strokes.FeatureAchievements.IdeIntegration;
using StructureMap;

namespace Strokes.FeatureAchievements
{
    public class IdeIntegrationAchievementObserver
    {
        private readonly IAchievementService _achievementService;
        protected List<IdeIntegrationAchievement> IdeIntegrationAchievements;

        public IdeIntegrationAchievementObserver(IServiceContainer serviceContainer, IAchievementService achievementService)
        {
            _achievementService = achievementService;

            IdeIntegrationAchievements = _achievementService.GetUnlockableAchievements().Where(a => typeof(IdeIntegrationAchievement).IsAssignableFrom(a.AchievementType))
                                                                                .Select(a => (IdeIntegrationAchievement)Activator.CreateInstance(a.AchievementType, serviceContainer))
                                                                                .ToList();

            //Wire events.
            foreach(var integrationAchievement in IdeIntegrationAchievements)
            {
                integrationAchievement.AchievementUnlocked += IntegrationAchievementUnlocked;
            }
        }

        private void IntegrationAchievementUnlocked(object sender, EventArgs e)
        {
            var ideIntegrationAchievement = sender as IdeIntegrationAchievement;
            if (ideIntegrationAchievement != null)
            {
                ideIntegrationAchievement.Dispose();
                IdeIntegrationAchievements.Remove(ideIntegrationAchievement);
                _achievementService.UnlockAchievement(ideIntegrationAchievement);
            }
        }
    }
}