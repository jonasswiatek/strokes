using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescriptor("{f991cf0a-4bb8-4490-a0e1-b3227bdbfdef}", "@TwitterChallengeName", 
        AchievementDescription = "@TwitterChallengeDescription", 
        AchievementCategory = "@Challenges")]
    public class TwitterChallenge : Challenge
    {
        public TwitterChallenge() : base("Strokes.Challenges.CaesarChallenge.TwitterTest") 
        {
        }
    }
}
