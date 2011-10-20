using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Strokes.Core.Service.Model;

namespace Strokes.GUI
{
    public class AchievementNotificationViewModel
    {
        public AchievementNotificationViewModel()
        {
            CurrentAchievements = new ObservableCollection<Achievement>();
        }

        public ObservableCollection<Achievement> CurrentAchievements
        {
            get;
            set;
        }
    }
}
