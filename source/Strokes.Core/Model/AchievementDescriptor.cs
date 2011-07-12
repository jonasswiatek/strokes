using System;

namespace Strokes.Core.Model
{
    public class AchievementDescriptor
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
        
        public string ImageUri
        {
            get;
            set;
        }

        public Type AchievementType
        {
            get;
            set;
        }

        public AchievementCodeLocation CodeLocaton
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
    }
}