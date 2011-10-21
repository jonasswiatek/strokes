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
        protected List<IdeIntegrationAchievement> IdeIntegrationAchievements;
        protected IAchievementService AchievementService;
        public IdeIntegrationAchievementObserver(Package shell)
        {
            IdeIntegrationAchievements = AchievementService.GetAllAchievements().Where(a => typeof (IdeIntegrationAchievement)
                                                                                .IsAssignableFrom(a.AchievementType))
                                                                                .Select(a => (IdeIntegrationAchievement) Activator.CreateInstance(a.AchievementType, shell))
                                                                                .ToList();

            //Wire events.
            foreach(var integrationAchievement in IdeIntegrationAchievements)
            {
                integrationAchievement.AchievementUnlocked += (sender, args) =>
                                                                  {
                                                                      var ideIntegrationAchievement = sender as IdeIntegrationAchievement;
                                                                      if (ideIntegrationAchievement != null)
                                                                      {
                                                                          IdeIntegrationAchievements.Remove(ideIntegrationAchievement);
                                                                          AchievementService.UnlockAchievement(ideIntegrationAchievement);
                                                                      }
                                                                  };
            }
        }
    }
}
