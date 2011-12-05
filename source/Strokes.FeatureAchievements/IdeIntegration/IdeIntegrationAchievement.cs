using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Strokes.Core;

namespace Strokes.FeatureAchievements.IdeIntegration
{
    public abstract class IdeIntegrationAchievement : AchievementBase, IDisposable
    {
        public event EventHandler<EventArgs> AchievementUnlocked;

        protected IdeIntegrationAchievement(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;
        }

        protected IServiceContainer ServiceContainer
        {
            get;
            private set;
        }

        protected void OnAchievementUnlocked()
        {
            if (AchievementUnlocked != null)
            {
                AchievementUnlocked(this, new EventArgs());
            }
        }

        protected void Unlock()
        {
            OnAchievementUnlocked();
        }

        public void Dispose()
        {
            AchievementUnlocked = null;
            DisposeAchievement();
        }

        public abstract void DisposeAchievement();

        protected T GetService<T>()
        {
            return (T)ServiceContainer.GetService(typeof(T));
        }
    }
}