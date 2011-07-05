using System;

namespace Strokes.Core.Model
{
    public class AchievementDescriptor
    {
        // Explicit data
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUri { get; set; }
        public Type AchievementType { get; set; }

        // Inferable data
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}