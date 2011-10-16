using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(DeclareMultipleDimArrayAchievement))]
    public class MultiDimArrayTest
    {
        public int[,] multiDimArray;
    }
}