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
            #region keep closed unless you really want to see ugly code
            var achievementDescriptorRepository = new AchievementDescriptorRepository();
            var achievs = achievementDescriptorRepository.GetAll(); //Please note that this method returns another object that the AchievementTracker.GetAllAchievementDescriptors(). It needs to be rewritten to run on this new dataobject (Strokes.Core.Model.AchievementDescriptor).
            achievementsOrdered = new ObservableCollection<AchievementsPerCategory>();

            //1° should we be doing this here? Better if this happens in achievementrepo?

            //Get all categories
            List<string> allcats = new List<string>();
            foreach (var ach in achievs)
            {
                if (!allcats.Contains(ach.Category))
                {
                    allcats.Add(ach.Category);
                    achievementsOrdered.Add(new AchievementsPerCategory() { CategoryName = ach.Category });
                }

                //Insert into correct category
                var achcat = (from p in achievementsOrdered where p.CategoryName == ach.Category select p).Single();
                achcat.Add(ach);
            }




            if (System.Diagnostics.Debugger.IsAttached)
            {
                achievementsOrdered.Add(new AchievementsPerCategory() { CategoryName = "Test" });
                achievementsOrdered[1].Add(new AchievementDescriptor() { Description = "Test 1 2 3", Name = "Debug achievement" });
                achievementsOrdered[1].Add(new AchievementDescriptor() { Description = "Test 1 2 3 completed", Name = "Debug achievement", IsCompleted = true });
            }
            #endregion
            
            
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
