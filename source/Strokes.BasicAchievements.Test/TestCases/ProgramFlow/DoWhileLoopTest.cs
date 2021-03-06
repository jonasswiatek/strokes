﻿using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ProgramFlow
{
    [ExpectUnlock(typeof(DoWhileLoopAchievement))]
    [ExpectUnlock(typeof(DeclareInitializeInt))]
    [ExpectUnlock(typeof(PlusPlusOperatorAchievement))]
    public class DoWhileLoopTest
    {
        public void Test()
        {
            int i = 0;
            
            do
            {
                i++;
            }
            while (i < 10);
        }
    }
}