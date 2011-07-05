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
        public AllAchievementsViewModel()
        {
            LoadModel();

            AchievementContext.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
        }

        private void LoadModel()
        {
            var achievementDescriptorRepository = new AchievementDescriptorRepository();
            var achievs = achievementDescriptorRepository.GetAll(); //Please note that this method returns another object that the AchievementTracker.GetAllAchievementDescriptors(). It needs to be rewritten to run on this new dataobject (Strokes.Core.Model.AchievementDescriptor).
            
            //by Jonas: Fancy pants extension method that uses linq. AchievementCategory is now part of Strokes.Core.Model as well
            var achievementCategories = achievs.AsCategories();

            #region keep closed unless you really want to see ugly code
            
            achievementsOrdered = new ObservableCollection<AchievementsPerCategory>();
            //1° should we be doing this here? Better if this happens in catagory?
            //2° I think somewhat with some linq-experience can do this in 1 or 2 step?

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
                achcat.Achievements.Add(ach);
            }

            //DEbug test
            achievementsOrdered.Add(new AchievementsPerCategory() { CategoryName = "Test" });
            achievementsOrdered[1].Achievements.Add(new AchievementDescriptor() { Description = "Test 1 2 3", Name = "Debug achievement" });
            #endregion
        }

        void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {

            LoadModel();
            OnPropertyChanged("achievementsOrdered");
        }




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
    }

    public class AchievementsPerCategory 
    {
        public string CategoryName { get; set; }
        public ObservableCollection<AchievementDescriptor> Achievements { get; set; }

        public AchievementsPerCategory()
        {
            CategoryName = "Not Set";
            Achievements = new ObservableCollection<AchievementDescriptor>();
        }

    }
}
