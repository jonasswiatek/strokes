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
        public ObservableCollection<AchievementsPerCategory> achievementsOrdered { get;private set; }

        public int TotalAchievements { get { return (from t in achievementsOrdered select t.Count).Sum(); }  }
        public int TotalCompleted { get { return (from t in achievementsOrdered select t.TotalCompleted).Sum(); } }
        public int PercentageCompleted { get { return TotalAchievements != 0 ?   (int)(((double)TotalCompleted / (double)TotalAchievements)*100):  0;}
          
        }

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
  
        }

        void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            foreach (var ach in args.Achievements)
            {
                foreach (var cat in achievementsOrdered)
                {
                    if (ach.Category == cat.CategoryName)
                    {
                        cat.Update(ach);
                        break;
                    }
                }
            }
            OnPropertyChanged("achievementsOrdered");
            OnPropertyChanged("TotalCompleted");
            OnPropertyChanged("PercentageCompleted");
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

    public class AchievementsPerCategory:ObservableCollection<AchievementDescriptor>, INotifyPropertyChanged 
    {
                
        public string CategoryName { get; set; }        
        public int TotalCompleted {get { return (from t in this where t.IsCompleted==true select t).Count(); } }
        public int PercentageCompleted { get { return this.Count != 0 ? (int)(((double)TotalCompleted / (double)this.Count) * 100) : 0; } }

        public AchievementsPerCategory()
        {
            CategoryName = "Not Set";  
        }


        internal void Update(AchievementDescriptor ach)
        {
            var achtorefresh = (from a in this where a.Name == ach.Name select a).SingleOrDefault();
            achtorefresh = ach;
            OnPropertyChanged("TotalCompleted");
            OnPropertyChanged("PercentageCompleted");
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
}
