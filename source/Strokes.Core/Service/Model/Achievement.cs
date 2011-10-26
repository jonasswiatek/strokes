using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Strokes.Core.Service.Model
{
    public class Achievement : INotifyPropertyChanged
    {
        public Achievement()
        {
            DependsOn = new List<Achievement>();
            Unlocks = new List<Achievement>();
        }

        public string Guid
        {
            get;
            set;
        }

        public List<Achievement> DependsOn
        {
            get;
            set;
        }

        public List<Achievement> Unlocks
        {
            get;
            set;
        }

        public string DependsOnStr
        {
            get
            {
                if (DependsOn.Any())
                    return string.Join(" ", DependsOn.Select(a => "[" + a.Name + "]"));
                else
                    return string.Empty;
            }
        }

        public string UnlocksStr
        {
            get
            {
                if (Unlocks.Any())
                    return string.Join(" ", Unlocks.Select(a => "[" + a.Name + "]"));  
                else
                    return string.Empty;
            }
        }

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

        public Uri HintUri { get; set; }

        public Type AchievementType
        {
            get;
            set;
        }

        public AchievementCodeOrigin CodeOrigin
        {
            get;
            set;
        }

        public string CodeSnippet { get; set; }

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