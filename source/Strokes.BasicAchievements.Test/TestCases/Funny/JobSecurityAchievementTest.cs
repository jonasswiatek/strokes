using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(JobSecurityAchievement))]
    [ExpectUnlock(typeof(QueryExpressionAchievement))]
    [ExpectUnlock(typeof(InstantiateObjectAchievement))]
    [ExpectUnlock(typeof(CreateGenericObjectAchievement))]
    [ExpectUnlock(typeof(OperatorAndAchievement))]
    public class JobSecurityAchievementTest
    {
        public void Method()
        {
            var list = new List<Type>();
            var result = from a in list
                         where a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                               && a.FullName.IndexOf('c') > 0
                         select a;
        }
    }
}