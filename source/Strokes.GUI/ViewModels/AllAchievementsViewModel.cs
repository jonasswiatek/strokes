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
            var achievements = repository.GetAll();

            foreach (var category in achievements.AsCategories())
            {
                //var sortedAchievements = category.Achievements
                //        .OrderByDescending(a => a.IsCompleted)
                //        .ThenBy(a => a.DateCompleted)
                //        .ThenBy(a => a.Description);

                AchievementsOrdered.Add(new AchievementsPerCategory(category.Achievements)
                {
                    CategoryName = category.CategoryName,
                });
            }
        }

        private void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            foreach (var achievement in args.Achievements)
            {
                foreach (var category in AchievementsOrdered)
                {
                    if (achievement.Category == category.CategoryName)
                    {
                        category.Update(achievement);
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
            CategoryName = "Unknown";
        }

        public AchievementsPerCategory(IEnumerable<AchievementDescriptor> collection)
            : base(collection)
        {
            CategoryName = "Unknown";
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
            var achievementDescriptor = this.SingleOrDefault(a => a.Name == descriptor.Name);

            if (achievementDescriptor != null)
            {
                InsertItem(this.IndexOf(achievementDescriptor), descriptor);

                RaisePropertyChanged("TotalCompleted");
                RaisePropertyChanged("PercentageCompleted");
            }
        }

        internal void RaisePropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected override void InsertItem(int index, AchievementDescriptor item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                switch (Math.Sign(this[i].CompareTo(item)))
                {
                    case 0:
                        throw new InvalidOperationException("Cannot insert duplicated items");
                    case 1:
                        base.InsertItem(i, item);
                        return;
                    case -1:
                        break;
                }
            }
 
            base.InsertItem(this.Count, item);
        }
    }
}
