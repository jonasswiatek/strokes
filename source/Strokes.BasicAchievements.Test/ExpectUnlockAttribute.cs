using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.BasicAchievements.Test
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExpectUnlockAttribute : Attribute
    {
        public Type ExpectedAchievementType;

        public ExpectUnlockAttribute(Type expectedAchievementType)
        {
            ExpectedAchievementType = expectedAchievementType;
        }
    }
}