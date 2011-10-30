using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.Challenges.Common;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Challenges.CaesarChallenge;
using Strokes.Core;
using Strokes.Core.Service;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescriptor("{698F100C-F6DB-48AB-B7DA-8AAC22F76A84}", "@CaesarChallengeName", 
        AchievementDescription = "@CaesarChallengeDescription", 
        HintUrl = "http://en.wikipedia.org/wiki/Caesar_cipher",
        AchievementCategory = "@Challenges")]
    public class CaesarChallenge : TestableChallenge<ICaesar, CaesarTest>
    {
    }
}