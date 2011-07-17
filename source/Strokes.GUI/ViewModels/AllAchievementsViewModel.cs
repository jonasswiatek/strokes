using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Strokes.Core;
using Strokes.Core.Model;
using Strokes.Data;

namespace Strokes.GUI
{
    public class AllAchievementsViewModel : ViewModelBase
    {
        private const string OrderedAchievementsFieldName = "AchievementsOrdered";
        private const string TotalAchievementsFieldName = "TotalAchievements";
        private const string TotalCompletedFieldName = "TotalCompleted";
        private const string PercentageCompletedFieldName = "PercentageCompleted";

        public AllAchievementsViewModel()
        {
            this.AchievementsOrdered = new ObservableCollection<AchievementsPerCategory>();
            this.ResetCommand = new RelayCommand(ResetExecute);

            ReloadViewModel();

            AchievementContext.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
        }

        public ObservableCollection<AchievementsPerCategory> AchievementsOrdered
        {
            get;
            private set;
        }

        public ICommand ResetCommand
        {
            get;
            private set;
        }

        public int TotalAchievements
        {
            get
            {
                return AchievementsOrdered.Sum(t => t.Count);
            }
        }

        public int TotalCompleted
        {
            get
            {
                return AchievementsOrdered.Sum(t => t.TotalCompleted);
            }
        }

        public int PercentageCompleted
        {
            get
            {
                return TotalAchievements != 0 ? (int)(((double)TotalCompleted / (double)TotalAchievements) * 100) : 0;
            }

        }

        private void ResetExecute()
        {
            new AchievementDescriptorRepository().ResetCompletedAchievements();
        }

        private void ReloadViewModel()
        {
            AchievementsOrdered.Clear();

            var repository = new AchievementDescriptorRepository();
            var achivements = repository.GetAll();
            var categories = achivements.AsCategories();

            foreach (var category in categories)
            {
                var archivementCategory = new AchievementsPerCategory()
                {
                    CategoryName = category.CategoryName,
                };

                foreach (var achivement in category.Achievements)
                {
                    archivementCategory.Add(achivement);
                }

                AchievementsOrdered.Add(archivementCategory);
            }
        }

        private void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            foreach (var achivement in args.Achievements)
            {
                foreach (var category in AchievementsOrdered)
                {
                    if (achivement.Category == category.CategoryName)
                    {
                        category.Update(achivement);
                        break;
                    }
                }
            }

            RaisePropertyChanged(OrderedAchievementsFieldName);
            RaisePropertyChanged(TotalCompletedFieldName);
            RaisePropertyChanged(PercentageCompletedFieldName);
        }
    }

    public class AchievementsPerCategory : ObservableCollection<AchievementDescriptor>, INotifyPropertyChanged
    {
        public AchievementsPerCategory()
        {
            CategoryName = "Not Set";
        }

        public string CategoryName
        {
            get;
            set;
        }

        public int TotalCompleted
        {
            get
            {
                return this.Count(t => t.IsCompleted);
            }
        }

        public int PercentageCompleted
        {
            get
            {
                return this.Count != 0 ? (int)(((double)TotalCompleted / (double)this.Count) * 100) : 0;
            }
        }

        internal void Update(AchievementDescriptor descriptor)
        {
            var achivementDescriptor = this.SingleOrDefault(a => a.Name == descriptor.Name);

            if (achivementDescriptor != null)
            {
                achivementDescriptor = descriptor;
            }

            RaisePropertyChanged("TotalCompleted");
            RaisePropertyChanged("PercentageCompleted");
        }

        internal void RaisePropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
