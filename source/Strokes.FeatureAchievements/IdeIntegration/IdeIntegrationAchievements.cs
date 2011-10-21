using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;
using Strokes.Core;

namespace Codecube.Strokes_FeatureAchievements.IdeIntegration
{
    public abstract class IdeIntegrationAchievement : AchievementBase
    {
        public Package Shell { get; private set; }

        protected IdeIntegrationAchievement(Package shell)
        {
            Shell = shell;
        }
    }
}