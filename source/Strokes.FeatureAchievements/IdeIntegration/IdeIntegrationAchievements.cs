using System;
using Microsoft.VisualStudio.Shell;
using Strokes.Core;

namespace Strokes.FeatureAchievements.IdeIntegration
{
    public abstract class IdeIntegrationAchievement : AchievementBase, IDisposable
    {
        protected Package Shell { get; private set; }
        public event EventHandler<EventArgs> AchievementUnlocked;

        protected IdeIntegrationAchievement(Package shell)
        {
            Shell = shell;
        }

        protected void OnAchievementUnlocked()
        {
            Dispose();
            if(AchievementUnlocked != null)
            {
                AchievementUnlocked(this, new EventArgs());
            }
        }

        public void Dispose()
        {
            AchievementUnlocked = null;
            DisposeAchievement();
        }

        public abstract void DisposeAchievement();
    }
}