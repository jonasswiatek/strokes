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
using System.Collections.Specialized;

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
                var sortedAchievements = category.Achievements
                        .OrderByDescending(a => a.IsCompleted)
                        .ThenByDescending(a => a.DateCompleted)
                        .ThenBy(a => a.Name);

                AchievementsOrdered.Add(new AchievementsPerCategory(sortedAchievements)
                {
                    CategoryName = category.CategoryName,
                });
            }
        }

        private void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            foreach (var achievement in args.Achievements)
            {
                var category = AchievementsOrdered.FirstOrDefault(c => c.CategoryName == achievement.Category);
                if (category != null)
                    category.Update(achievement);
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
                achievementDescriptor = descriptor;
                
                ApplySort();

                RaisePropertyChanged("TotalCompleted");
                RaisePropertyChanged("PercentageCompleted");
            }
        }

        internal void RaisePropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void ApplySort()
        {
             var sortedItems = this.OrderByDescending(a => a.IsCompleted)
                                   .ThenByDescending(a => a.DateCompleted)
                                   .ThenBy(a => a.Name)
                                   .ToList();

            foreach (var item in sortedItems)
            {
                Move(IndexOf(item), sortedItems.IndexOf(item));
            }
        }
    }
}
