using System;

namespace Strokes.Core.Model
{
    public class AchievementDescriptor : IComparable<AchievementDescriptor>
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

        #region IComparable<AchievementDescriptor> Members

        public int CompareTo(AchievementDescriptor other)
        {
            return other.IsCompleted.CompareTo(this.IsCompleted) 
                + this.DateCompleted.CompareTo(other.DateCompleted)
                + this.Description.CompareTo(other.Description);
        }

        #endregion
    }
}