using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Model
{
    public class CompletedAchievement
    {
        public CompletedAchievement()
        {
        }

        public CompletedAchievement(AchievementDescriptor achievementDescriptor)
        {
            Name = achievementDescriptor.Name;
        }

        // Inferable data
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }

        //Equals, hashcode and all that jazz
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CompletedAchievement)) return false;
            return Equals((CompletedAchievement) obj);
        }

        public bool Equals(CompletedAchievement other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return other.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ IsCompleted.GetHashCode();
                result = (result*397) ^ DateCompleted.GetHashCode();
                return result;
            }
        }
    }
}