using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescription("Caesar", AchievementDescription = "Write a Caesar encryption/decryption module", AchievementCategory = "Challenges")]
    public class CaesarChallenge : Challenge
    {
        public CaesarChallenge() : base("Strokes.Challenges.Student.CaesarChallenge.CaesarTest") 
        {
        }
    }
}
