using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Strokes.Core.Data.Model
{
    public class Achievement : INotifyPropertyChanged
    {
        public string Guid { get; set; }

        public IEnumerable<Achievement> DependsOn { get; set; }
        public IEnumerable<Achievement> Unlocks { get; set; }

        public string Name
        {
            get;
            set;
        }
        
        public string Description
        {
            get;
            set;
        }
        
        public string Category
        {
            get;
            set;
        }
        
        public string Image
        {
            get;
            set;
        }

        public Type AchievementType
        {
            get;
            set;
        }

        public AchievementCodeLocation CodeLocation
        {
            get;
            set;
        }

        public bool IsCompleted
        {
            get;
            set;
        }

        public DateTime DateCompleted
        {
            get;
            set;
        }

        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}