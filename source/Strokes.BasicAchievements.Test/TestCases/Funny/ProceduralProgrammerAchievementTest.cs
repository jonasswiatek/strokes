using System;
using System.Collections.Generic;
using System.Linq;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.Funny
{
    [ExpectUnlock(typeof(ProceduralProgrammerAchievement))]
    [ExpectUnlock(typeof(OutParameterAchievement))]
    [ExpectUnlock(typeof(CreateMethodMultipleParametersAchievement))]
    [ExpectUnlock(typeof(ParametizerAchievement))]
    public class ProceduralProgrammerAchievementTest
    {
        public void LooksLikePain(out string a, out string b, out string c, out string d, out string e, out string f, out string g, out string h, out string i, out string j, out string k, out string l)
        {
            a = "";
            b = "";
            c = "";
            d = "";
            e = "";
            f = "";
            g = "";
            h = "";
            i = "";
            j = "";
            k = "";
            l = "";
        }
    }
}