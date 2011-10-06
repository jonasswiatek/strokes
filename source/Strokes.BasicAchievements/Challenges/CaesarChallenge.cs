using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescription("@CaesarChallengeName", 
        AchievementDescription = "@CaesarChallengeDescription", 
        AchievementCategory = "@Challenges")]
    public class CaesarChallenge : Challenge
    {
        public CaesarChallenge() : base("Strokes.Challenges.CaesarChallenge.CaesarTest") 
        {
        }
    }
}
