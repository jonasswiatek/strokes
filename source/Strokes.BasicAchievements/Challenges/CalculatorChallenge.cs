using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.Challenges.Common;
using Strokes.Challenges.CalculatorChallenge;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescriptor("{31A0B042-488A-47F0-84DC-627DDC4524B5}", "@CalculatorChallengeName",
        AchievementDescription = "@CalculatorChallengeDescription", 
        HintUrl = "http://en.wikipedia.org/wiki/Calculator",
        AchievementCategory = "@Challenges")]
    public class CalculatorChallenge : TestableChallenge<ICalculator, CalculatorTest>
    {
    }
}