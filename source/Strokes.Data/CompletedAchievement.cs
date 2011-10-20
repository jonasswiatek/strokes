using System;
using Strokes.Core.Data.Model;
using Strokes.Core.Service.Model;

namespace Strokes.Data
{
    public class CompletedAchievement
    {
        public CompletedAchievement()
        {
            Guid = string.Empty;
        }

        public CompletedAchievement(Achievement achievementDescriptor)
        {
            Guid = achievementDescriptor.Guid;
        }

        public string Guid
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != typeof(CompletedAchievement))
                return false;

            return Equals((CompletedAchievement)obj);
        }

        public bool Equals(CompletedAchievement other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            return other.Guid.Equals(Guid);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Guid != null ? Guid.GetHashCode() : 0);
                
                return result;
            }
        }
    }
}