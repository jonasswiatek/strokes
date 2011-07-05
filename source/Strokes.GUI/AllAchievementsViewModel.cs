using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Data;
using Strokes.Core.Model;
using System.Collections.ObjectModel;
using Strokes.Core;
using System.ComponentModel;

namespace Strokes.GUI
{
    public class AllAchievementsViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<AchievementsPerCategory> achievementsOrdered { get; set; }
        public int TotalCompleted { get; set; }
        public int TotalAchievements { get; set; }
        public AllAchievementsViewModel()
        {
            ReLoadModel();
            
            AchievementContext.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
        }

        private void ReLoadModel()
        {
            
            achievementsOrdered = new ObservableCollection<AchievementsPerCategory>();

            var achievementDescriptorRepository = new AchievementDescriptorRepository();
            var achievs = achievementDescriptorRepository.GetAll(); //Please note that this method returns another object that the AchievementTracker.GetAllAchievementDescriptors(). It needs to be rewritten to run on this new dataobject (Strokes.Core.Model.AchievementDescriptor).
            var achcats = achievs.AsCategories();

            foreach (var achcat in achcats)
            {
                AchievementsPerCategory cattoadd= new AchievementsPerCategory(){CategoryName= achcat.CategoryName};
                foreach (var ach in achcat.Achievements)
                    cattoadd.Add(ach);
                achievementsOrdered.Add(cattoadd);
            }
   
            TotalAchievements = (from t in achievementsOrdered select t.Count).Sum();
            TotalCompleted = (from t in achievementsOrdered select t.TotalCompleted).Sum();
           
        }

        void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            ReLoadModel();
            OnPropertyChanged("achievementsOrdered");
            OnPropertyChanged("TotalCompleted");
        }

        #region INotify stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) 
            {
               var e = new PropertyChangedEventArgs(propertyName);
               handler(this, e);
            }

        }
        #endregion
    }

    public class AchievementsPerCategory:ObservableCollection<AchievementDescriptor> 
    {
                
        public string CategoryName { get; set; }        
        public int TotalCompleted { get; set; }
       

        public AchievementsPerCategory()
        {
            CategoryName = "Not Set";
            TotalCompleted = 0;
           
        }

        protected override void InsertItem(int index, AchievementDescriptor item)
        {
            if (item.IsCompleted)
                TotalCompleted++;
            
            base.InsertItem(index, item);
        } 

    }
}
