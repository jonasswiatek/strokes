using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescription("@CalculatorChallengeName",
        AchievementDescription = "@CalculatorChallengeDescription", 
        AchievementCategory = "@Challenges")]
    public class CalculatorChallenge : Challenge
    {
        public CalculatorChallenge() : base("Strokes.Challenges.CalculatorChallenge.CalculatorTest") 
        {
        }
    }
}
