using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Strokes.Core;
using Strokes.FeatureAchievements.IdeIntegration;

namespace Strokes.FeatureAchievements.Achievements
{
    [AchievementDescriptor(
        "{60263C58-5C3B-45A0-9702-ED1F272AC3F7}", "@DemoFeatureAchievementName",
        AchievementDescription = "@DemoFeatureAchievementNameDescription",
        AchievementCategory = "@IDE"
    )]
    public class DemoFeatureAchievement : IdeIntegrationAchievement
    {
        protected readonly DTE Dte;
        private Timer timer;

        public DemoFeatureAchievement(IServiceContainer shell)
            : base(shell)
        {
            // TODO: Your turn Jonas.
            timer = new Timer(obj =>
            {
                Unlock();
            }, null, 20000, Timeout.Infinite);
        }

        public override void DisposeAchievement()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer = null;
            }
        }
    }
}
