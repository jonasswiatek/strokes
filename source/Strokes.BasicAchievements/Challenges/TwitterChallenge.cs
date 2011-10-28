using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescriptor("{f991cf0a-4bb8-4490-a0e1-b3227bdbfdef}", "@TwitterChallengeName", 
        AchievementDescription = "@TwitterChallengeDescription", 
        HintUrl = "http://www.blogoneanother.com/2009/04/twitter-characters-d-rt.html",
        AchievementCategory = "@Challenges")]
    public class TwitterChallenge : Challenge
    {
        public TwitterChallenge() : base("Strokes.Challenges.TwitterChallenge.TwitterTest") 
        {
        }
    }
}
