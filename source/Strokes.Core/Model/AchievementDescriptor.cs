using System;
using System.ComponentModel;

namespace Strokes.Core.Model
{
    public class AchievementDescriptor : INotifyPropertyChanged
    {
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