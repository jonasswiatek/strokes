using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Expressions
{
    [ExpectUnlock(typeof(QueryExpressionAchievement))]
    public class QueryExpressionTest
    {
        public void Test()
        {
            var items = new List<int>() { 1, 2, 3, 4 };
            
            var result = from i in items where i > 2 select i;
        }
    }
}
