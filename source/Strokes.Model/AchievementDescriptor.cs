using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Model
{
    public class AchievementDescriptor
    {
        // Explicit data
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Type AchievementType { get; set; }

        // Inferable data
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}