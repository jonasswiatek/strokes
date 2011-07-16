using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Strokes.Core.Model;

namespace Strokes.GUI
{
    public class AchivementNotificationViewModel
    {
        public AchivementNotificationViewModel()
        {
            this.CurrentAchievements = new ObservableCollection<AchievementDescriptor>();            
        }

        public ObservableCollection<AchievementDescriptor> CurrentAchievements
        {
            get;
            set;
        }
    }
}
