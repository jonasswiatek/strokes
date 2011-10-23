using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core.Service.Model;

namespace Strokes.GUI
{
    public class AchievementUIContext
    {
        public delegate void AchievementClickedHandler(object sender, AchievementClickedEventArgs args);
        public static event AchievementClickedHandler AchievementClicked;

        public static void OnAchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            if (AchievementClicked != null)
            {
                AchievementClicked(sender, args);
            }
        }
    }

    public class AchievementClickedEventArgs
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
