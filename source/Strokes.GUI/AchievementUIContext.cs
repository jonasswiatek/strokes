using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using Strokes.Core.Data.Model;

namespace Strokes.GUI
{
    public delegate void AchievementClickedEventHandler(object sender, AchievementClickedEventArgs args);

    public class AchievementUIContext
    {
        public static event AchievementClickedEventHandler AchievementClicked;

        public static void OnAchievementsUnlocked(Achievement achievement, object uiElement)
        {
            if (AchievementClicked != null)
            {
                AchievementClicked(uiElement, new AchievementClickedEventArgs
                {
                    AchievementDescriptor = achievement,
                    UIElement = uiElement
                });
            }
        }
    }

    public class AchievementClickedEventArgs : EventArgs
    {
        public Achievement AchievementDescriptor
        {
            get;
            set;
        }

        public object UIElement
        {
            get;
            set;
        }
    }
}
