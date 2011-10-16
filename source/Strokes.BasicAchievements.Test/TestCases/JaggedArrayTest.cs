using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases
{
    [ExpectUnlock(typeof(DeclareArrayAchievement))]
    [ExpectUnlock(typeof(JaggedArrayAchievement))]
    public class JaggedArrayTest
    {
        public int[][] jaggedArray;
    }
}